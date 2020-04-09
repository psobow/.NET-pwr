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
        private readonly string CURRENCY_RATE_FORMAT = "-.----";
        private ClientNBP clientNBP = ClientNBP.Instance;

        // current currency rates from web API references
        private CurrencyModel EURFromWebAPI;
        private CurrencyModel USDFromWebAPI;
        private CurrencyModel GBPFromWebAPI;
        private GoldModel GoldFromWebAPI;

        public MainWindow()
        {
            InitializeComponent();
            resetUI();
            Loger.appBeginTextWithTime(textBox_AppLoger, "App has started sucessfully");
        }


        #region web API interface implementation
        private async void button_getCurrentExchangeRates_Click(object sender, RoutedEventArgs e)
        {
            // Send HTTP requests
            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for current EUR rate...\n");
            string eurResponseJSON = await clientNBP.getCurrentEURAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + eurResponseJSON);

            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for current USD rate...\n");
            string usdResponseJSON = await clientNBP.getCurrentUSDAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + usdResponseJSON);

            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for current GBP rate...\n");
            string gbpResponseJSON = await clientNBP.getCurrentGBPAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + gbpResponseJSON);

            Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for current Gold rate...\n");
            string goldResponseJSON = await clientNBP.getCurrentGoldPrizeAsync();
            Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + goldResponseJSON);

            // Map JSON  to POCO
            EURFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(eurResponseJSON);
            USDFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(usdResponseJSON);
            GBPFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(gbpResponseJSON);
            GoldFromWebAPI = JsonConvert.DeserializeObject<GoldModel[]>(goldResponseJSON)[0];

            // Extract current currencies date
            DateTime currentCurrencyRatesDate = EURFromWebAPI.rates[0].effectiveDate;

            // Extract currency rates
            double EURRate = EURFromWebAPI.rates[0].mid;
            double USDRate = USDFromWebAPI.rates[0].mid;
            double GBPRate = GBPFromWebAPI.rates[0].mid;
            double GoldRate = GoldFromWebAPI.cena;

            // Update UI 
            textBlock_DateOfDataFromWebAPI.Text = "Concurency rates in " + currentCurrencyRatesDate.ToString(InputValidator.DATE_FORMAT) + " from WEB API";
            textBlock_EUR_RateFromWebAPI.Text = EURRate.ToString() + " PLN";
            textBlock_USD_RateFromWebAPI.Text = USDRate.ToString() + " PLN";
            textBlock_GBP_RateFromWebAPI.Text = GBPRate.ToString() + " PLN";
            textBlock_Gold_RateFromWebAPI.Text = GoldRate.ToString() + " PLN / Gram";

        }

        private async void button_getExchangesRatesFromSpecificDate_Click(object sender, RoutedEventArgs e)
        {
            string inputDate = textBox_insertDate_1.Text;

            bool isInputDateFormatValid = InputValidator.validateDateFormat(inputDate);
            bool isInputDateValid = InputValidator.validateDate(inputDate);
            bool isValid = isInputDateFormatValid && isInputDateValid; 

            if (isValid)
            {
                // Send HTTP requests
                Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for EUR rate from " + inputDate + "...\n");
                string eurResponseJSON = await clientNBP.getEURFromSpecificDateAsync(inputDate);
                Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + eurResponseJSON);

                Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for USD rate from " + inputDate + "...\n");
                string usdResponseJSON = await clientNBP.getUSDFromSpecificDateAsync(inputDate);
                Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + usdResponseJSON);

                Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for GBP rate from " + inputDate + "...\n");
                string gbpResponseJSON = await clientNBP.getGBPFromSpecificDateAsync(inputDate);
                Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + gbpResponseJSON);

                Loger.appBeginTextWithTime(textBox_AppLoger, "Sending GET HTTP request for Gold rate from " + inputDate + "...\n");
                string goldResponseJSON = await clientNBP.getGoldFromSpecificDateAsync(inputDate);
                Loger.appBeginTextWithTime(textBox_AppLoger, "Response: " + goldResponseJSON);

                // Map JSON to POCO if JSON's presents
                EURFromWebAPI = eurResponseJSON != "" ? JsonConvert.DeserializeObject<CurrencyModel>(eurResponseJSON) : null;
                USDFromWebAPI = usdResponseJSON != "" ? JsonConvert.DeserializeObject<CurrencyModel>(usdResponseJSON) : null;
                GBPFromWebAPI = gbpResponseJSON != "" ? JsonConvert.DeserializeObject<CurrencyModel>(gbpResponseJSON) : null;
                GoldFromWebAPI = goldResponseJSON != "" ? JsonConvert.DeserializeObject<GoldModel[]>(goldResponseJSON)[0] : null;

                // Extract currency rates if objects presents
                double? EURRate = EURFromWebAPI?.rates[0].mid;
                double? USDRate = USDFromWebAPI?.rates[0].mid;
                double? GBPRate = GBPFromWebAPI?.rates[0].mid;
                double? GoldRate = GoldFromWebAPI?.cena;

                // Update UI 
                textBlock_DateOfDataFromWebAPI.Text = "Concurency rates in " + inputDate + " from WEB API";
                textBlock_EUR_RateFromWebAPI.Text = (EURRate.HasValue ? EURRate.Value.ToString() : CURRENCY_RATE_FORMAT) + " PLN";
                textBlock_USD_RateFromWebAPI.Text = (USDRate.HasValue ? USDRate.Value.ToString() : CURRENCY_RATE_FORMAT) + " PLN";
                textBlock_GBP_RateFromWebAPI.Text = (GBPRate.HasValue ? GBPRate.Value.ToString() : CURRENCY_RATE_FORMAT) + " PLN";
                textBlock_Gold_RateFromWebAPI.Text = (GoldRate.HasValue ? GoldRate.Value.ToString() : CURRENCY_RATE_FORMAT) + " PLN / Gram";
            }
            else if (!isInputDateFormatValid)
            {
                MessageBox.Show("Invalid date format. Please insert date in given format: " + InputValidator.DATE_FORMAT, "WEB API INTERFACE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("Invalid date. Please insert valid date!", "WEB API INTERFACE", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

        #region auxiliary app functionalities implementation

        // RESET UI
        private void button_resetUI_Click(object sender, RoutedEventArgs e)
        {
            resetUI();
            Loger.appBeginTextWithTime(textBox_AppLoger, "App UI has been reset");

            // Reset objects references
            EURFromWebAPI = null;
            USDFromWebAPI = null;
            GBPFromWebAPI = null;
            GoldFromWebAPI = null;
    }


        private void resetUI()
        {
            // Reset textBoxes_insertDate
            resetTextBoxInsertDate(textBox_insertDate_1);
            resetTextBoxInsertDate(textBox_insertDate_2);
            resetTextBoxInsertDate(textBox_insertDate_3);
            resetTextBoxInsertDate(textBox_insertDate_4);

            // Reset labeles
            textBlock_DateOfDataFromWebAPI.Text = "Concurency rates in " + InputValidator.DATE_FORMAT + " from WEB API";
            textBlock_LogerForDatabaseData.Text = "Concurency rates from " + InputValidator.DATE_FORMAT + " to " + InputValidator.DATE_FORMAT;
            textBlock_DateOfDataFromDatabase.Text = "Concurency rates in " + InputValidator.DATE_FORMAT + " from DB";

            // Reset currency rates from web API
            textBlock_EUR_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT + " PLN";
            textBlock_GBP_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT + " PLN";
            textBlock_USD_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT + " PLN";
            textBlock_Gold_RateFromWebAPI.Text = CURRENCY_RATE_FORMAT + " PLN / Gram";

            // Reset currency rates from DB
            textBlock_EUR_RateFromDatabase.Text = CURRENCY_RATE_FORMAT + " PLN";
            textBlock_GBP_RateFromDatabase.Text = CURRENCY_RATE_FORMAT + " PLN";
            textBlock_USD_RateFromDatabase.Text = CURRENCY_RATE_FORMAT + " PLN";
            textBlock_Gold_RateFromDatabase.Text = CURRENCY_RATE_FORMAT + " PLN / Gram";

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
            textBox.Text = InputValidator.DATE_FORMAT;
            textBox.Foreground = Brushes.Gray;
        }

        // First text box
        private void textBox_insertDate_1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_insertDate_1.Text == InputValidator.DATE_FORMAT)
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
            if (textBox_insertDate_2.Text == InputValidator.DATE_FORMAT)
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
            if(textBox_insertDate_3.Text == InputValidator.DATE_FORMAT)
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
            if (textBox_insertDate_4.Text == InputValidator.DATE_FORMAT)
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
