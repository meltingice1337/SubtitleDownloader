using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace SubtitleDownloader
{
    static class FileShellExtension
    {
        public static void RemoveContextMenuItem(string extension, string menuName)
        {
            if (!ContextMenuExists(extension, menuName)) return;

            var rkey = Registry.ClassesRoot.OpenSubKey(extension);
            if (rkey != null)
            {
                string extstring = rkey.GetValue("").ToString();
                rkey.Close();
                if (extstring != null)
                {
                    if (extstring.Length > 0)
                    {
                        rkey = Registry.ClassesRoot.OpenSubKey(extstring, true);
                        if(rkey != null)
                            rkey.DeleteSubKeyTree("shell\\" + menuName);
                    }
                }
            }
        }

        public static bool ContextMenuExists(string extension, string menuName)
        {
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(extension);
            if (rkey != null)
            {
                string extstring = rkey.GetValue("").ToString();
                rkey.Close();
                if (extstring != null)
                {
                    if (extstring.Length > 0)
                    {
                        rkey = Registry.ClassesRoot.OpenSubKey(
                          extstring, true);
                        if (rkey != null)
                        {
                            string strkey = "shell\\" + menuName + "\\command";
                            RegistryKey subky = rkey.OpenSubKey(strkey);
                            if (subky != null)
                            {
                                return true;
                            }
                            rkey.Close();
                        }
                    }
                }
            }
            return false;
        }

        public static void AddContextMenuItem(string extension, string menuName, string menuDescription, string menuCommand)
        {
            RegistryKey rkey = Registry.ClassesRoot.OpenSubKey(extension);
            if (rkey != null)
            {
                string extstring = rkey.GetValue("").ToString();
                rkey.Close();
                if (extstring != null)
                {
                    if (extstring.Length > 0)
                    {
                        rkey = Registry.ClassesRoot.OpenSubKey(
                          extstring, true);
                        if (rkey != null)
                        {
                            string strkey = "shell\\" + menuName + "\\command";
                            RegistryKey subky = rkey.CreateSubKey(strkey);
                            if (subky != null)
                            {
                                subky.SetValue("", menuCommand);
                                subky.Close();
                                subky = rkey.OpenSubKey("shell\\" + menuName, true);
                                if (subky != null)
                                {
                                    subky.SetValue("", menuDescription);
                                    subky.Close();
                                }
                            }
                            rkey.Close();
                        }
                    }
                }
            }
        }
    }
}
