using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SubtitleDownloader
{
    class Addic7edClass
    {
        public static List<Subtitle> Parse(string pageContent)
        {
            var result = new List<Subtitle>();
            foreach (var mainMatch in Regex.Matches(pageContent, @"<div id=""container95m"">([\s\S]*?)</div>"))
            {
                var version = Regex.Match(mainMatch.Value, @"(?<=Version )(.*?)(?=,)").Value;
                foreach (Match langMatch in Regex.Matches(mainMatch.Value, @"<tr>([\s\S]*?)</tr>"))
                {
                    var language = Regex.Match(langMatch.Value, @"(?<=class=""language"">)(.*?)(?=<)").Value;
                    if (language != "")
                    {
                        var completed = Regex.Match(langMatch.Value, @"(?<=<td width=""19%""><b>)([\s\S]*?)(?=</b>)").Value;
                        if (completed.Contains("%")) completed = completed.Replace("Completed", "");
                        var download = Regex.Match(langMatch.Value, @"(?<=<a class=""buttonDownload"" href="")(.*?)(?="">)").Value;
                        result.Add(new Subtitle(language, version, completed, download));
                    }
                }
            }
            return result;
        }
    }
}