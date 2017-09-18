using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Info
{
    class Presenter
    {
        Model model = null;
        MainWindow mainWindow = null;
        SortedDictionary<string, string> city = new SortedDictionary<string, string>();
        //SortedDictionary<string, string> currencies = new SortedDictionary<string, string>();
        List<string> curname = new List<string>();
        string eurusd = "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[3]/td[3]";
        string gbpusd = "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[5]/td[3]";
        string audusd = "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[6]/td[3]";
        string usdjpy = "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[4]/td[3]";
        string nzdusd = "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[7]/td[3]";


        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            city = model.GetURLAndNameCitys("http://meteo.gov.ua", "//div[@class='selec1']/a[@class='m13']"); 
            if (city != null)
            {
                foreach (var item in city)
                {
                    this.mainWindow.ComboBox2.Items.Add(item.Key);
                }
            }
            else
            {
                this.mainWindow.ComboBox2.Items.Add("City didn't found");
            }
            this.mainWindow.ComboBox2.SelectedIndex = 0;
            this.mainWindow.myEvent += new EventHandler(mainWindow_myEvent);

            //currencies = model.GetURLAndNameCitys("https://finance.yahoo.com/currencies", "//tr[@class='data-rowEURUSD=X']/td[@class='data-col2']");
            curname.Add("EUR/USD");
            curname.Add("GBP/USD");
            curname.Add("AUD/USD");
            curname.Add("NZD/USD");
            curname.Add("USD/JPY");
           
            if (curname != null)
            {
                foreach (var item in curname)
                {
                    this.mainWindow.ComboBox1_Copy4.Items.Add(item);
                }
            }
        }

        private void mainWindow_myEvent(object sender, EventArgs e)
        {
            string siteUrl2 = mainWindow.ComboBox1_Copy4.Text;
            string siteUrl = city[mainWindow.ComboBox2.Text];

            if(mainWindow.ComboBox1_Copy4.Text == "EUR/USD")
            {
                var fininfo = model.GetData("https://finance.yahoo.com/currencies", "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[3]/td[3]");
                mainWindow.Label2_Copy1.Content = fininfo;
            }

            if (mainWindow.ComboBox1_Copy4.Text == "GBP/USD")
            {
                var fininfo = model.GetData("https://finance.yahoo.com/currencies", "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[5]/td[3]");
                mainWindow.Label2_Copy1.Content = fininfo;
            }

            if (mainWindow.ComboBox1_Copy4.Text == "AUD/USD")
            {
                var fininfo = model.GetData("https://finance.yahoo.com/currencies", "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[6]/td[3]");
                mainWindow.Label2_Copy1.Content = fininfo;
            }

            if (mainWindow.ComboBox1_Copy4.Text == "NZD/USD")
            {
                var fininfo = model.GetData("https://finance.yahoo.com/currencies", "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[7]/td[3]");
                mainWindow.Label2_Copy1.Content = fininfo;
            }

            if (mainWindow.ComboBox1_Copy4.Text == "USD/JPY")
            {
                var fininfo = model.GetData("https://finance.yahoo.com/currencies", "//*[@id='yfin-list']/div[2]/div/table/tbody/tr[4]/td[3]");
                mainWindow.Label2_Copy1.Content = fininfo;
            }


            var temperature = model.GetData(siteUrl, "//*[@id='curWeatherT']");

            if (temperature != null)
            {
                mainWindow.Label4.Content = temperature + " °C";
            }
            else
            {
                mainWindow.Label4.Content = "No info";
            }




            //var city = model.GetData("http://meteo.gov.ua/ua/33345", "//*[@class='hdr_fr_bl1_sity']");
            //if (city != null)
            //{
            //    mainWindow.Label3.Content = city;
            //}
            //else
            //{
            //    mainWindow.Label1.Content = "No info";
            //}
        }

        //private void mainWindow_myEvent2(object sender, EventArgs e)
        //{
        //    string siteUrl = currencies[mainWindow.ComboBox1_Copy4.Text];
        //    var price = model.GetData(siteUrl, "//*[@id='curWeatherT']");
        //    if (price != null)
        //    {
        //        mainWindow.Label4.Content = price;
        //    }
        //    else
        //    {
        //        mainWindow.Label4.Content = "No info";
        //    }


        //}
    }
}
