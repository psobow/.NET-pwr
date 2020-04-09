using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public sealed class ClientNBP
    {
        private readonly string[] supportedCurrencyNames = { "EUR", "USD", "GBP" };
        private readonly string NBP_API_BASE_URL = "http://api.nbp.pl/api/exchangerates/rates/a";
        
        // Singleton
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

        public async Task<string> GetAsync(string currency)
        { 
            bool isCurrencyValid = validateCurrency(currency);

            if (!isCurrencyValid)
            {
                throw new System.ArgumentException("Parameter currency name has to be string EUR or USD or GBP", "currency");
            }

            string uri = (NBP_API_BASE_URL + "/" + currency + "/?format=json");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }


/*        public string Get(string currency)
        {
            string uri = (NBP_API_BASE_URL + "/" + currency + "/?format=json");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
        */

        private bool validateCurrency(string currency)
        {
            // Check if array supported currency names contains string currency
            return supportedCurrencyNames.ToList().Any(x => x.Equals(currency));
        }
    }

}
