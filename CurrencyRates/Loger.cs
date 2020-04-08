using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CurrencyRates
{
    public class Loger
    {
        public static void appBeginText(TextBox textBox, string str)
        {
            DateTime localDate = DateTime.Now;
            textBox.Text = "<" + localDate.ToLongTimeString() + "> " + str + "\n" + textBox.Text;
        }
    }
}
