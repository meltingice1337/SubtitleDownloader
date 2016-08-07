using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using SubtitleDownloader.Utilities;

namespace SubtitleDownloader
{
    public partial class FrmMain : Form
    {
        private bool SearchStarted = false;
        private bool Downloading = false;
        private string DownloadPath;
        private string FileName;

        public FrmMain(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                string filename = Path.GetFileNameWithoutExtension(args[0]);
                FileName = filename;
                DownloadPath = Path.GetDirectoryName(args[0]);
            }
            else
            {
                DownloadPath = Path.GetDirectoryName(Application.ExecutablePath);
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (FileShellExtension.ContextMenuExists(".mkv", "DownloadSubtitle"))
                chkContextMenu.Checked = true;

            txtQuery.Text = FileName;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtQuery.Text)) return;
            FileName = txtQuery.Text;
            Search(txtQuery.Text);
        }

        private void Search(string query)
        {
            if (SearchStarted) return;
            SetStatus("Searching ...");
            lstSubtitles.ClearItems();
            (new Thread(() =>
            {
                SearchStarted = true;
                BeginInvoke((MethodInvoker)delegate{  btnSearch.Enabled = false; });
                var pageContent = Web.GetSearch(query);
                if (pageContent != null)
                {
                    var subtitles = Addic7edClass.Parse(pageContent);
                    InsertItems(subtitles);
                    if (subtitles.Count > 0)
                        SetStatus(subtitles.Count.ToString() + " subtitles found.");
                    else
                        SetStatus("No subtitles found");
                }
                else
                {
                    SetStatus("Error.");
                }
                SearchStarted = false;
                BeginInvoke((MethodInvoker)delegate{  btnSearch.Enabled = true; });
            })).Start();
        }

        private void InsertItems(List<Subtitle> subtitles)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                int key = 0;
                var imageList = new ImageList();
                foreach (var subtitle in subtitles)
                {
                    imageList.Images.Add(Helper.GetResource(subtitle.Language.ToLower()));
                    var item = new ListViewItem(new[] { subtitle.Language, subtitle.Version, subtitle.Completed });
                    item.ImageIndex = key++;
                    lstSubtitles.Items.Add(item);
                    item.Tag = subtitle.Download;
                }
                lstSubtitles.SmallImageList = imageList;
            });
        }

        private void lstSubtitles_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            var url = (string)lstSubtitles.SelectedItems[0].Tag;
            if (lstSubtitles.SelectedItems.Count == 0 || Downloading) return;
            (new Thread(() =>
            {
                Downloading = true;
                SetStatus("Downloading file...");
                Web.Download(url, Path.Combine(DownloadPath, FileName + ".srt"));
                SetStatus("Done");
                Downloading = false;
            })).Start();
        }

        private void SetStatus(string status)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                lblStatusValue.Text = status;
            });
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FileName))
            {
                this.Focus();
                Search(FileName);
            }
        }

        private void chkContextMenu_CheckedChanged(object sender, EventArgs e)
        {
            var menuDescription = "Download subtitle";
            var menuCommand = string.Format("\"{0}\" \"%L\"", Application.ExecutablePath);
            var menuName = "DownloadSubtitle";
            var extensions = new string[] { ".mkv", ".webm", ".flv", ".mp4", ".avi" };

            if (chkContextMenu.Checked)
            {
                chkContextMenu.Text = "Remove from context menu";
                foreach (var extension in extensions)
                {
                    FileShellExtension.AddContextMenuItem(extension, menuName, menuDescription, menuCommand);
                }
            }
            else
            {
                chkContextMenu.Text = "Add to context menu";
                foreach (var extension in extensions)
                {
                    FileShellExtension.RemoveContextMenuItem(extension, menuName);
                }
            }
        }

        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string query = Path.GetFileNameWithoutExtension(files[0]);

            txtQuery.Text = query;
            FileName = query;
            DownloadPath = Path.GetDirectoryName(files[0]);

            Search(query);
        }
    }
}
