using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfBasics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FirstButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("First button has been clicked!");
        }

        private async void AddNewLog_Click(object sender, RoutedEventArgs e)
        {
            string responseJSON = await CurrencyClient.GetAsync("USD");

            DateTime localDate = DateTime.Now;
            logsTextBox.Text = "<" + localDate.ToLongTimeString() + ">" + responseJSON + "\n" + logsTextBox.Text;

            CurrencyModel currencyModel = JsonConvert.DeserializeObject<CurrencyModel>(responseJSON);
            double rate = currencyModel.rates[0].mid;
            logsTextBox.Text = rate + "\n" + logsTextBox.Text;
        }


    }
}
/*
 * 
 * TODO:
 * 
 * https://stackoverflow.com/questions/7010462/how-to-make-wpf-textbox-with-a-scrollbar-automatically-scroll-to-the-bottom-when/49918567
 * https://stackoverflow.com/questions/1192335/automatic-vertical-scroll-bar-in-wpf-textblock
 * 
 * public ObservableCollection<Currency> Items
 * {
 *  get => currencies;
 * }
 */

