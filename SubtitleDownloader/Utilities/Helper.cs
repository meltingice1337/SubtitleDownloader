using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Resources;

namespace SubtitleDownloader.Utilities
{
    class Helper
    {
        public static Image GetResource(string name)
        {
            try
            {
                var t = (Image)Properties.Resources.ResourceManager.GetObject(name, Properties.Resources.Culture);
                if(t != null)
                    return t;
                else
                return Properties.Resources.uknown;
            }
            catch
            {
                return Properties.Resources.uknown;
            }
        }
    }
}
