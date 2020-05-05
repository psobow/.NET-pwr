using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public class GoldModel
    {



        [Key]
        public int GoldModelId { get; set; }
        public DateTime data { get; set; }
        public double cena { get; set; }
    }
}
