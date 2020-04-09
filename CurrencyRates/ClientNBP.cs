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
        private readonly string NBP_API_BASE_URL = "http://api.nbp.pl/api";
        
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



        #region get actual rates
        // GET ACTUAL RATES

        public async Task<string> getActualEURRateAsync()
        {
            return await GetActualCurrencyAsync("EUR");
        }

        public async Task<string> getActualUSDRateAsync()
        {
            return await GetActualCurrencyAsync("USD");
        }

        public async Task<string> getActualGBPRateAsync()
        {
            return await GetActualCurrencyAsync("GBP");
        }

        public async Task<string> getActualGoldPrizeAsync()
        {
            string uri = "http://api.nbp.pl/api/cenyzlota/?format=json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private async Task<string> GetActualCurrencyAsync(string currency)
        {
            bool isCurrencyValid = validateCurrency(currency);

            if (!isCurrencyValid)
            {
                throw new System.ArgumentException("Parameter currency name has to be string EUR or USD or GBP", "currency");
            }

            string uri = (NBP_API_BASE_URL + "/exchangerates/rates/a/" + currency + "/?format=json");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private bool validateCurrency(string currency)
        {
            // Check if array supported currency names contains string currency
            return supportedCurrencyNames.ToList().Any(x => x.Equals(currency));
        }
        #endregion

        // GET SPECIFIC DATE RATES



    }

}
