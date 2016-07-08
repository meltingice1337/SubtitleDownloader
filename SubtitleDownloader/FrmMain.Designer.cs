namespace SubtitleDownloader
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.lblStatusValue = new System.Windows.Forms.Label();
            this.chkContextMenu = new System.Windows.Forms.CheckBox();
            this.lstSubtitles = new SubtitleDownloader.ListViewEx();
            this.hLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hCompleted = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 402);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(268, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(16, 12);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(246, 20);
            this.txtQuery.TabIndex = 2;
            // 
            // lblStatusValue
            // 
            this.lblStatusValue.AutoSize = true;
            this.lblStatusValue.Location = new System.Drawing.Point(59, 402);
            this.lblStatusValue.Name = "lblStatusValue";
            this.lblStatusValue.Size = new System.Drawing.Size(55, 13);
            this.lblStatusValue.TabIndex = 3;
            this.lblStatusValue.Text = "Waiting ...";
            // 
            // chkContextMenu
            // 
            this.chkContextMenu.AutoSize = true;
            this.chkContextMenu.Location = new System.Drawing.Point(190, 402);
            this.chkContextMenu.Name = "chkContextMenu";
            this.chkContextMenu.Size = new System.Drawing.Size(138, 17);
            this.chkContextMenu.TabIndex = 5;
            this.chkContextMenu.Text = "Add to contextual menu";
            this.chkContextMenu.UseVisualStyleBackColor = true;
            this.chkContextMenu.CheckedChanged += new System.EventHandler(this.chkContextMenu_CheckedChanged);
            // 
            // lstSubtitles
            // 
            this.lstSubtitles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSubtitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hLanguage,
            this.hVersion,
            this.hCompleted});
            this.lstSubtitles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lstSubtitles.FullRowSelect = true;
            this.lstSubtitles.GridLines = true;
            this.lstSubtitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstSubtitles.Location = new System.Drawing.Point(15, 38);
            this.lstSubtitles.MultiSelect = false;
            this.lstSubtitles.Name = "lstSubtitles";
            this.lstSubtitles.Size = new System.Drawing.Size(328, 361);
            this.lstSubtitles.TabIndex = 4;
            this.lstSubtitles.UseCompatibleStateImageBehavior = false;
            this.lstSubtitles.View = System.Windows.Forms.View.Details;
            this.lstSubtitles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstSubtitles_MouseDoubleClick);
            // 
            // hLanguage
            // 
            this.hLanguage.Text = "Language";
            this.hLanguage.Width = 90;
            // 
            // hVersion
            // 
            this.hVersion.Text = "Version";
            this.hVersion.Width = 150;
            // 
            // hCompleted
            // 
            this.hCompleted.Text = "Completed";
            this.hCompleted.Width = 84;
            // 
            // FrmMain
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 419);
            this.Controls.Add(this.chkContextMenu);
            this.Controls.Add(this.lstSubtitles);
            this.Controls.Add(this.lblStatusValue);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(371, 457);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(371, 457);
            this.Name = "FrmMain";
            this.Text = "SubtitleDownloader";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label lblStatusValue;
        private ListViewEx lstSubtitles;
        private System.Windows.Forms.ColumnHeader hLanguage;
        private System.Windows.Forms.ColumnHeader hVersion;
        private System.Windows.Forms.ColumnHeader hCompleted;
        private System.Windows.Forms.CheckBox chkContextMenu;
    }
}

