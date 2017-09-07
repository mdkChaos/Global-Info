using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HtmlAgilityPack;

namespace Global_Info
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var web = new HtmlWeb();

            var page = web.Load("https://finance.yahoo.com/currencies");

            HtmlNode eurusd = page.DocumentNode.SelectSingleNode("//*[@id='yfin-list']/div[2]/div/table/tbody/tr[3]/td[3]");

            if (eurusd != null)
            {
                Label2.Content = eurusd.InnerText;
            }
            else
                Label2.Content = "No info";
        }

        
          





    }
}
