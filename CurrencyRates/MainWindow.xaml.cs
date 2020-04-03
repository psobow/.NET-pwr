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
        public MainWindow()
        {
            InitializeComponent();
        }





        // IMPLEMENT PLACE HOLDER FUNCTIONALITY

        // First text box
        private void Text_box_insert_date_1_GotFocus(object sender, RoutedEventArgs e)
        {
            if (text_box_insert_date_1.Text == "RRRR-MM-DD")
            {
                text_box_insert_date_1.Text = "";
                text_box_insert_date_1.Foreground = Brushes.Black;
            }
        }

        private void Text_box_insert_date_1_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_box_insert_date_1.Text))
            {
                text_box_insert_date_1.Text = "RRRR-MM-DD";
                text_box_insert_date_1.Foreground = Brushes.Gray;
            }
        }

        // Second text box
        private void Text_box_insert_date_2_GotFocus(object sender, RoutedEventArgs e)
        {
            if (text_box_insert_date_2.Text == "RRRR-MM-DD")
            {
                text_box_insert_date_2.Text = "";
                text_box_insert_date_2.Foreground = Brushes.Black;
            }
        }

        private void Text_box_insert_date_2_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_box_insert_date_2.Text))
            {
                text_box_insert_date_2.Text = "RRRR-MM-DD";
                text_box_insert_date_2.Foreground = Brushes.Gray;
            }
        }

        // Third text box
        private void Text_box_insert_date_3_GotFocus(object sender, RoutedEventArgs e)
        {
            if(text_box_insert_date_3.Text == "RRRR-MM-DD")
            {
                text_box_insert_date_3.Text = "";
                text_box_insert_date_3.Foreground = Brushes.Black;
            }
        }

        private void Text_box_insert_date_3_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_box_insert_date_3.Text))
            {
                text_box_insert_date_3.Text = "RRRR-MM-DD";
                text_box_insert_date_3.Foreground = Brushes.Gray;
            }
        }

        // Fourth text box
        private void Text_box_insert_date_4_GotFocus(object sender, RoutedEventArgs e)
        {
            if (text_box_insert_date_4.Text == "RRRR-MM-DD")
            {
                text_box_insert_date_4.Text = "";
                text_box_insert_date_4.Foreground = Brushes.Black;
            }
        }

        private void Text_box_insert_date_4_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_box_insert_date_4.Text))
            {
                text_box_insert_date_4.Text = "RRRR-MM-DD";
                text_box_insert_date_4.Foreground = Brushes.Gray;
            }
        }
    }
}
