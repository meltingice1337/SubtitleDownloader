using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using SubtitleDownloader.Utilities;
using System.Linq;

namespace SubtitleDownloader
{

    class ShowInfo
    {
        public string name;
        public string season;
        public string episode;
        public string meta;
        public ShowInfo(string name, string season, string episode, string meta)
        {
            this.name = name;
            this.season = season;
            this.episode = episode;
            this.meta = meta;
        }
    }

    class Show
    {
        public int id;
        public string name;
        public int levensthein;
    }

    class Web
    {
        private const string SearchLink = "http://www.addic7ed.com/search.php?search={0}&anti_cache={1}";
        private static string Referer;

        public static string GetSearch(string q)
        {
            try
            {
                var match = Regex.Match(q, "(.*?)[Ss]?(\\d+)[xXeE]+?(\\d+)(.*)");
                ShowInfo fi = new ShowInfo(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value, match.Groups[4].Value);
                var showId = GetShowId(fi);
                if (showId == -1) return null;
                var request = (HttpWebRequest)WebRequest.Create($"http://www.addic7ed.com/re_episode.php?ep={showId}-{fi.season}x{fi.episode}&anti-cache={DateTime.Now.ToString()}");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Referer = "http://www.addic7ed.com";
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

        public static int GetShowId(ShowInfo q)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(string.Format("http://www.addic7ed.com/ajax_getShows.php?anti-cache=", DateTime.Now.ToString()));
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:47.0) Gecko/20100101 Firefox/47.0";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.Referer = "http://www.addic7ed.com";
                request.Headers["Accept-Language"] = "en-US,en;q=0.5";
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                Referer = response.ResponseUri.ToString();

                List<Show> l = new List<Show>();

                foreach (Match match in Regex.Matches(responseString, "<option value=\"(\\d+?)\" >(.*?)</option>"))
                {
                    l.Add(new Show { name = match.Groups[2].Value, id = int.Parse(match.Groups[1].Value), levensthein = LevenshteinDistance.Compute(match.Groups[2].Value, q.name) });
                }
                l = l.OrderBy(i => i.levensthein).ToList();

                return l.First().id;
            }
            catch (WebException ex)
            {
                return -1;
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
