using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public class CurrencyModel
    {
        // PK
        [Key]
        public int CurrencyModelId { get; set; }
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public List<Rate> Rates { get; set; }
    }

    public class Rate
    {
        // PK
        [Key]
        public int RateId { get; set; }
        public string no { get; set; }
        public DateTime effectiveDate { get; set; }
        public double mid { get; set; }

        // FK
        //[ForeignKey("CurrencyModel")]
        //public int CurrencyModelId { get; set; }
        
        public CurrencyModel CurrencyModel { get; set; }
    }
}
