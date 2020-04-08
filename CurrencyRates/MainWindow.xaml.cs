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
        private const string DATE_FORMAT = "RRRR-MM-DD";
        private const string CURRENCY_RATE_FORMAT = "-.---- PLN";
        
        public MainWindow()
        {
            InitializeComponent();
            resetUI();
        }



        #region auxiliary app functionalities

        // RESET UI
        private void button_resetUI_Click(object sender, RoutedEventArgs e)
        {
            resetUI();
        }


        private void resetUI()
        {
            // Reset textBoxes_insertDate
            resetTextBoxInsertDate(textBox_insertDate_1);
            resetTextBoxInsertDate(textBox_insertDate_2);
            resetTextBoxInsertDate(textBox_insertDate_3);
            resetTextBoxInsertDate(textBox_insertDate_4);

            // Reset labeles
            textBlock_DateOfDataFromWebAPI.Text = "Concurency rates in RRRR-MM-DD from WEB API";
            textBlock_LogerForDatabaseData.Text = "Concurency rates from RRRR-MM-DD to RRRR-MM-DD";
            textBlock_DateOfDataFromDatabase.Text = "Concurency rates in RRRR-MM-DD from DB";

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

            // Log information about reset UI
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
