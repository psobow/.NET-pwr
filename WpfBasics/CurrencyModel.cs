using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBasics
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


/*
 * https://riptutorial.com/json-net/example/6086/how-to-install-json-net-in-visual-studio-projects
 * 
{
    "table":"A",
    "currency":"dolar amerykański",
    "code":"USD",
    "rates":[
    {
        "no":"065/A/NBP/2020",
        "effectiveDate":"2020-04-02",
        "mid":4.1917
    }]
}
*/
