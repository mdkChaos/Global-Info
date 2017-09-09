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
            return weather.InnerText;

            //var page = web.Load("http://meteo.gov.ua/ua/33791");
            //var page = web.Load("https://finance.yahoo.com/currencies");
            //HtmlNode eurusd = page.DocumentNode.SelectSingleNode("//*[@id='yfin-list']/div[2]/div/table/tbody/tr[3]/td[3]");
            //HtmlNode weather = page.DocumentNode.SelectSingleNode("//*[@id='curWeatherT']");
        }
    }
}
