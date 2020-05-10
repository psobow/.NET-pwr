using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CurrencyRates
{


    /// <summary>
    /// Logika interakcji dla klasy CurrencyCharts.xaml
    /// </summary>
    public partial class CurrencyCharts : Window
    {
        private CurrencyDbContext dbContext = new CurrencyDbContext();

        public CurrencyCharts(string Currency)
        {
            InitializeComponent();
            LoadLineChartData(Currency);
            
            
        }


       
        private void LoadLineChartData(string currencyName)
        {
            if (currencyName.Equals("GOLD"))
            {
                var Gold = dbContext.GetGold();
                var sortedList = from element in Gold
                                 orderby element.data
                                 select element;
                var list = new List<KeyValuePair<string, double>>();
               
                foreach (var value in sortedList)
                {
                    list.Add(new KeyValuePair<string, double>(value.data.ToShortDateString(), value.cena));
                }
               
                 ((LineSeries)mcChart.Series[0]).ItemsSource = list;
                
                mcChart.LegendTitle = currencyName;
            }
            else
            {
                var nameOfCurrency = dbContext.GetDbRates(currencyName);
                var sortedList = from element in nameOfCurrency
                               orderby element.effectiveDate
                             select element;
                var list = new List<KeyValuePair<string, double>>();
                foreach (var currency in sortedList)
                {
                    list.Add(new KeyValuePair<string, double>(currency.effectiveDate.ToShortDateString(), currency.mid));
                }
               ((LineSeries)mcChart.Series[0]).ItemsSource = list;
                
                mcChart.LegendTitle = currencyName;
            }    
           
           
        }
    }
}
