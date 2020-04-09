using Newtonsoft.Json;
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

namespace CurrencyRates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string DATE_FORMAT = "YYYY-MM-DD";
        private const string CURRENCY_RATE_FORMAT = "-.---- PLN";
        private ClientNBP clientNBP = ClientNBP.Instance;

        // Currency rates
        private double EURRate;
        private double USDRate;
        private double GBPRate;
        private double GoldRate;
        private DateTime dataDate;

        public MainWindow()
        {
            InitializeComponent();
            resetUI();
            Loger.appBeginTextWithTime(textBox_AppLoger, "App has started sucessfully");
        }


        #region web API interface implementation
        private async void get_actual_exchange_rates_Click(object sender, RoutedEventArgs e)
        {
            // Send HTTP requests
            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for actual EURO rate...");
            string eurResponseJSON = await clientNBP.getActualEURRateAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + eurResponseJSON);

            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for actual USD rate...");
            string usdResponseJSON = await clientNBP.getActualUSDRateAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + usdResponseJSON);

            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for actual GBP rate...");
            string gbpResponseJSON = await clientNBP.getActualGBPRateAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + gbpResponseJSON);

            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for actual Gold rate...");
            string goldResponseJSON = await clientNBP.getActualGoldPrizeAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + goldResponseJSON);

            // Map JSON  to POCO
            CurrencyModel eur = JsonConvert.DeserializeObject<CurrencyModel>(eurResponseJSON);
            CurrencyModel usd = JsonConvert.DeserializeObject<CurrencyModel>(usdResponseJSON);
            CurrencyModel gbp = JsonConvert.DeserializeObject<CurrencyModel>(gbpResponseJSON);
            GoldModel[] gold = JsonConvert.DeserializeObject<GoldModel[]>(goldResponseJSON);

            // Extract currency rates
            dataDate = eur.rates[0].effectiveDate;
            EURRate = eur.rates[0].mid;
            USDRate = usd.rates[0].mid;
            GBPRate = gbp.rates[0].mid;
            GoldRate = gold[0].cena;

            // Update UI 
            textBlock_DateOfDataFromWebAPI.Text = "Concurency rates in " + dataDate.ToString("yyyy-MM-dd") + " from WEB API";
            textBlock_EUR_RateFromWebAPI.Text = EURRate.ToString() + " PLN";
            textBlock_USD_RateFromWebAPI.Text = USDRate.ToString() + " PLN";
            textBlock_GBP_RateFromWebAPI.Text = GBPRate.ToString() + " PLN";
            textBlock_Gold_RateFromWebAPI.Text = GoldRate.ToString() + " PLN / Gram";

        }
        #endregion

        #region auxiliary app functionalities implementation

        // RESET UI
        private void button_resetUI_Click(object sender, RoutedEventArgs e)
        {
            resetUI();
            Loger.appBeginTextWithTime(textBox_AppLoger, "App UI has been reset");
        }


        private void resetUI()
        {
            // Reset textBoxes_insertDate
            resetTextBoxInsertDate(textBox_insertDate_1);
            resetTextBoxInsertDate(textBox_insertDate_2);
            resetTextBoxInsertDate(textBox_insertDate_3);
            resetTextBoxInsertDate(textBox_insertDate_4);

            // Reset labeles
            textBlock_DateOfDataFromWebAPI.Text = "Concurency rates in " + DATE_FORMAT + " from WEB API";
            textBlock_LogerForDatabaseData.Text = "Concurency rates from " + DATE_FORMAT + " to " + DATE_FORMAT;
            textBlock_DateOfDataFromDatabase.Text = "Concurency rates in " + DATE_FORMAT + " from DB";

            // Reset currency rates from web API
            textBlock_EUR_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT;
            textBlock_GBP_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT;
            textBlock_USD_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT;
            textBlock_Gold_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT;

            // Reset currency rates from DB
            textBlock_EUR_RateFromDatabase.Text = CURRENCY_RATE_FORMAT;
            textBlock_GBP_RateFromDatabase.Text = CURRENCY_RATE_FORMAT;
            textBlock_USD_RateFromDatabase.Text = CURRENCY_RATE_FORMAT;
            textBlock_Gold_RateFromDatabase.Text = CURRENCY_RATE_FORMAT;

            // Reset database loger
            textBox_DatabaseLoger.Text = "";

            // Reset app loger
            textBox_AppLoger.Text = "";
        }

        // DELETE ALL DATA IN DATABASE
        private void deleteAllDataInDatabase()
        {

        }

        #endregion 

        #region place holders functionality
        // IMPLEMENT PLACE HOLDER FUNCTIONALITY

        private void resetTextBoxInsertDate(TextBox textBox)
        {
            textBox.Text = DATE_FORMAT;
            textBox.Foreground = Brushes.Gray;
        }

        // First text box
        private void textBox_insertDate_1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_insertDate_1.Text == DATE_FORMAT)
            {
                textBox_insertDate_1.Text = "";
                textBox_insertDate_1.Foreground = Brushes.Black;
            }
        }

        private void textBox_insertDate_1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_insertDate_1.Text))
            {
                resetTextBoxInsertDate(textBox_insertDate_1);
            }
        }

        // Second text box
        private void textBox_insertDate_2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_insertDate_2.Text == DATE_FORMAT)
            {
                textBox_insertDate_2.Text = "";
                textBox_insertDate_2.Foreground = Brushes.Black;
            }
        }

        private void textBox_insertDate_2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_insertDate_2.Text))
            {
                resetTextBoxInsertDate(textBox_insertDate_2);
            }
        }

        // Third text box
        private void textBox_insertDate_3_GotFocus(object sender, RoutedEventArgs e)
        {
            if(textBox_insertDate_3.Text == DATE_FORMAT)
            {
                textBox_insertDate_3.Text = "";
                textBox_insertDate_3.Foreground = Brushes.Black;
            }
        }

        private void textBox_insertDate_3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_insertDate_3.Text))
            {
                resetTextBoxInsertDate(textBox_insertDate_3);
            }
        }

        // Fourth text box
        private void textBox_insertDate_4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_insertDate_4.Text == DATE_FORMAT)
            {
                textBox_insertDate_4.Text = "";
                textBox_insertDate_4.Foreground = Brushes.Black;
            }
        }

        private void textBox_insertDate_4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_insertDate_4.Text))
            {
                resetTextBoxInsertDate(textBox_insertDate_4);
            }
        }
        #endregion

    }
}
