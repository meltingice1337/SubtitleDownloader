using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace SubtitleDownloader
{

    class Web
    {
        private const string SearchLink = "http://www.addic7ed.com/search.php?search={0}";
        private static string Referer;

        public static string GetSearch(string q)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(string.Format(SearchLink, q));
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Referer = response.ResponseUri.ToString();
                return responseString;
            }
            catch (WebException ex)
            {
                var response = (HttpWebResponse)ex.Response;
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Referer = response.ResponseUri.ToString();
                return responseString;
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
