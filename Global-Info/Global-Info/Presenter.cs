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

        public Presenter(MainWindow mainWindow)
        {
            this.model = new Model();
            this.mainWindow = mainWindow;
            this.mainWindow.myEvent += new EventHandler(mainWindow_myEvent);
        }

        void mainWindow_myEvent(object sender, EventArgs e)
        {
            string variable = model.GetData("http://meteo.gov.ua/ua/33791", "//*[@id='curWeatherT']");
            if (variable != null)
            {
                this.mainWindow.Label2.Content = variable;
            }
            else
                this.mainWindow.Label2.Content = "No info";
        }
    }
}
