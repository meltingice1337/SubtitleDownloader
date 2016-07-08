using System;
using System.Windows.Forms;

namespace SubtitleDownloader
{
    class ListViewEx : ListView
    {
        private const uint WM_CHANGEUISTATE = 0x127;
        private const int UIS_SET = 1;
        private const int UISF_HIDEFOCUS = 0x1;

        public ListViewEx() : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            this.View = View.Details;
            this.FullRowSelect = true;
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            Win32.SendMessage(this.Handle, WM_CHANGEUISTATE, NativeMethodsHelper.MakeLong(UIS_SET, UISF_HIDEFOCUS), 0);
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            return;
        }

        public void ClearItems()
        {
            this.Items.Clear();
        }
    }
}
