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

        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            city = model.GetURLAndNameCitys("http://meteo.gov.ua", "//div[@class='selec1']/a[@class='m13']");
            if (city != null)
            {
                foreach (var item in city)
                {
                    this.mainWindow.ComboBox1.Items.Add(item.Key);
                }
            }
            else
            {
                this.mainWindow.ComboBox1.Items.Add("City didn't found");
            }
            this.mainWindow.ComboBox1.SelectedIndex = 0;
            this.mainWindow.myEvent += new EventHandler(mainWindow_myEvent);
        }

        private void mainWindow_myEvent(object sender, EventArgs e)
        {
            string siteUrl = city[mainWindow.ComboBox1.Text];
            var temperature = model.GetData(siteUrl, "//*[@id='curWeatherT']");
            if (temperature != null)
            {
                mainWindow.Label2.Content = temperature + " °C";
            }
            else
            {
                mainWindow.Label2.Content = "No info";
            }
        }
    }
}
