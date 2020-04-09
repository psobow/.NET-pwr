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
        private readonly string NBP_API_BASE_URL = "http://api.nbp.pl/api";
        private readonly string RESPONSE_FORMAT = "?format=json";

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


        private async Task<string> sendGetAsync(string uri)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
            catch (WebException ex)
            {
                return "";
            }
        }


        #region get actual rates
        // GET ACTUAL RATES

        public async Task<string> getCurrentEURAsync()
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/EUR" + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getCurrentUSDAsync()
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/USD" + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getCurrentGBPAsync()
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/GBP" + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getCurrentGoldPrizeAsync()
        {
            string uri = NBP_API_BASE_URL + "/cenyzlota" + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        #endregion

        #region get specific date currency rates
        // GET SPECIFIC DATE RATES
        // TODO: implement date validation

        public async Task<string> getEURFromSpecificDateAsync(string date)
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/EUR/" + date + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getUSDFromSpecificDateAsync(string date)
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/USD/" + date + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getGBPFromSpecificDateAsync(string date)
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/GBP/" + date + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getGoldFromSpecificDateAsync(string date)
        {
            string uri = NBP_API_BASE_URL + "/cenyzlota/" + date + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        #endregion

        #region get period of time currency rates

        public async Task<string> getEURFromPeriodOfTime(string startDate, string endDate)
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/EUR/" + startDate + "/" + endDate + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getUSDFromPeriodOfTime(string startDate, string endDate)
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/USD/" + startDate + "/" + endDate + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getGBPFromPeriodOfTime(string startDate, string endDate)
        {
            string uri = NBP_API_BASE_URL + "/exchangerates/rates/a/GBP/" + startDate + "/" + endDate + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }

        public async Task<string> getGoldFromPeriodOfTime(string startDate, string endDate)
        {
            string uri = NBP_API_BASE_URL + "/cenyzlota/" + startDate + "/" + endDate + RESPONSE_FORMAT;
            return await sendGetAsync(uri);
        }
        #endregion
    }

}
