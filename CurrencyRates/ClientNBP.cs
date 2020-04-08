using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public sealed class ClientNBP
    {
        private ClientNBP()
        {
        }
        private static readonly Lazy<ClientNBP> lazy = new Lazy<ClientNBP>(() => new ClientNBP());
        public static ClientNBP Instance
        {
            get
            {
                return lazy.Value;
            }
        }
    }

}
