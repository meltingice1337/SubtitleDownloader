using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace SubtitleDownloader
{

    class Web
    {
        private const string SearchLink = "http://www.addic7ed.com/search.php?search={0}&anti_cache={1}";
        private static string Referer;

        public static string GetSearch(string q)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(string.Format(SearchLink, q, DateTime.Now.ToString()));
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Headers["Accept-Language"] = "en-US,en;q=0.5";
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Referer = response.ResponseUri.ToString();
                return responseString;
            }
            catch (WebException ex)
            {
                return null;
            }
        }

        public static void Download(string link, string path)
        {
            string url = "http://www.addic7ed.com" + link;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Referer = Referer;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            File.WriteAllText(path, responseString);
        }
    }
}
