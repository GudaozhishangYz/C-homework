using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace Homework9
{
    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000/";
            string startUrl2 = "http://quote.zhijinwang.com/xml/ag.txt";
            if (args.Length >= 1) startUrl = args[0];
            myCrawler.urls.Add(startUrl, false);
            myCrawler.urls.Add(startUrl2, false);
            Parallel.Invoke(new Action[]{
                    ()=> myCrawler.Crawl(startUrl),
                    ()=> myCrawler.Crawl(startUrl2)});
            Console.ReadLine();
        }

        private void Crawl(string url)
        {
            Console.WriteLine("start to run......");
            while (true)
            {
                string current = null;
                if ((bool)urls[url]) continue;
                 current = url;
                
                if (current == null || count > 10) break;
                Console.WriteLine("running in the" + current);
                string html = Download(current);
                urls[current] = true;
                count++;
                Prase(html);
            }
            Console.WriteLine("end the running");
        }

        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Prase(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][~""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef=match.Value.Substring(match.Value.IndexOf('=')+1).Trim('"', '\"', '#', ' ' ,'>');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
