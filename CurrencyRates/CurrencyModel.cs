using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public class CurrencyModel
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public List<Rates> rates { get; set; }
    }

    public class Rates
    {
        public string no { get; set; }
        public DateTime effectiveDate { get; set; }
        public double mid { get; set; }
    }
}
