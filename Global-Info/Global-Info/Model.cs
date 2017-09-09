using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Global_Info
{
    class Model
    {
        public string GetData(string webPage, string idTag)
        {
            var web = new HtmlWeb();
            var page = web.Load(webPage);
            HtmlNode weather = page.DocumentNode.SelectSingleNode(idTag);
            Dictionary<string, string> citys = new Dictionary<string, string>();
            var nodes = page.DocumentNode.SelectNodes("//*[@class='m13']");
            foreach (var node in nodes)
            {
                citys.Add(node.InnerText, node.Attributes[0].Value);
            }
            return weather.InnerText;
            //var page = web.Load("https://finance.yahoo.com/currencies");
            //HtmlNode eurusd = page.DocumentNode.SelectSingleNode("//*[@id='yfin-list']/div[2]/div/table/tbody/tr[3]/td[3]");
        }
        public SortedDictionary<string, string> GetURLAndNameCitys(string webPage, string idTag)
        {
            SortedDictionary<string, string> citys = new SortedDictionary<string, string>();
            var web = new HtmlWeb();
            var page = web.Load(webPage);
            var nodes = page.DocumentNode.SelectNodes(idTag);
            if (nodes != null)
            {
                foreach (var node in nodes)
                {
                    citys.Add(node.InnerText, node.Attributes[0].Value);
                }
            }
            return citys;
        }
    }
}
