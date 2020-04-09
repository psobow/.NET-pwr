using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public class InputValidator
    {
        public static readonly string DATE_FORMAT = "yyyy-MM-dd";
        private static readonly string DATE_FORMAT_REGEX_PATTERN = "^\\d\\d\\d\\d-\\d\\d-\\d\\d$";
        private static Regex dateFormatRegex = new Regex(DATE_FORMAT_REGEX_PATTERN);
        
        public static bool validateDateFormat(string date)
        {
            return dateFormatRegex.IsMatch(date);
        }

        public static bool validateDate(string date)
        {
            return true;
        }
    }
}
