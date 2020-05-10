using CurrencyRates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace CurrencyRates_testProject
{
    [TestClass]
    public class Test_ClientNBP
    {
        private ClientNBP clientNBP = ClientNBP.Instance;

        // SUCCESS SCENARIO

        // Current Values
        // Eur
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetEurCurrencyAsync()
        {
            // Given

            // When
            string eurResponseJSON = await clientNBP.getCurrentEURAsync();

            // Then
            CurrencyModel EURFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(eurResponseJSON);

            Assert.IsNotNull(EURFromWebAPI);
            Assert.IsNotNull(EURFromWebAPI.code);
            Assert.IsNotNull(EURFromWebAPI.currency);
            Assert.IsNotNull(EURFromWebAPI.Rates);
            Assert.IsNotNull(EURFromWebAPI.table);

            Assert.AreEqual(EURFromWebAPI.code, "EUR");
        }

        // USD
         [TestMethod]
        public async System.Threading.Tasks.Task shouldGetUsdCurrencyAsync()
        {
            // Given

            // When
            string usdResponseJSON = await clientNBP.getCurrentUSDAsync();

            // Then
            CurrencyModel USDFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(usdResponseJSON);

            Assert.IsNotNull(USDFromWebAPI);
            Assert.IsNotNull(USDFromWebAPI.code);
            Assert.IsNotNull(USDFromWebAPI.currency);
            Assert.IsNotNull(USDFromWebAPI.Rates);
            Assert.IsNotNull(USDFromWebAPI.table);

            Assert.AreEqual(USDFromWebAPI.code, "USD");
        }
        // GBP
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetGbpCurrencyAsync()
        {
            // Given

            // When
            string gbpResponseJSON = await clientNBP.getCurrentGoldAsync();

            // Then
            CurrencyModel GBPFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(gbpResponseJSON);

            Assert.IsNotNull(GBPFromWebAPI);
            Assert.IsNotNull(GBPFromWebAPI.code);
            Assert.IsNotNull(GBPFromWebAPI.currency);
            Assert.IsNotNull(GBPFromWebAPI.Rates);
            Assert.IsNotNull(GBPFromWebAPI.table);

            Assert.AreEqual(GBPFromWebAPI.code, "GBP");
        }

        // GOLD
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetGoldCurrencyAsync()
        {
            // Given

            // When
            string goldResponseJSON = await clientNBP.getCurrentGoldAsync();

            // Then
           GoldModel GoldFromWebAPI = JsonConvert.DeserializeObject<GoldModel>(goldResponseJSON);

            Assert.IsNotNull(GoldFromWebAPI);
            Assert.IsNotNull(GoldFromWebAPI.cena);
            Assert.IsNotNull(GoldFromWebAPI.data);
                     
        }


        // Period of time
        // EUR
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetEurCurrencyPeriodOfTimeAsync()
        {
            // Given

            // When
            string eurResponseJSON = await clientNBP.getEURFromPeriodOfTime("2020-03-01", "2020-04-01");

            // Then
            CurrencyModel EURFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(eurResponseJSON);

            Assert.IsNotNull(EURFromWebAPI);
            Assert.IsNotNull(EURFromWebAPI.code);
            Assert.IsNotNull(EURFromWebAPI.currency);
            Assert.IsNotNull(EURFromWebAPI.Rates);
            Assert.IsNotNull(EURFromWebAPI.table);

            Assert.AreEqual(EURFromWebAPI.code, "EUR");
        }

        // USD
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetUsdCurrencyPeriodOfTimeAsync()
        {
            // Given

            // When
            string usdResponseJSON = await clientNBP.getUSDFromPeriodOfTime("2020-03-01", "2020-04-01");

            // Then
            CurrencyModel USDFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(usdResponseJSON);

            Assert.IsNotNull(USDFromWebAPI);
            Assert.IsNotNull(USDFromWebAPI.code);
            Assert.IsNotNull(USDFromWebAPI.currency);
            Assert.IsNotNull(USDFromWebAPI.Rates);
            Assert.IsNotNull(USDFromWebAPI.table);

            Assert.AreEqual(USDFromWebAPI.code, "USD");
        }
        // GBP
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetGbpCurrencyPeriodOfTimeAsync()
        {
            // Given

            // When
            string gbpResponseJSON = await clientNBP.getGBPFromPeriodOfTime("2020-03-01", "2020-04-01");

            // Then
            CurrencyModel GBPFromWebAPI = JsonConvert.DeserializeObject<CurrencyModel>(gbpResponseJSON);

            Assert.IsNotNull(GBPFromWebAPI);
            Assert.IsNotNull(GBPFromWebAPI.code);
            Assert.IsNotNull(GBPFromWebAPI.currency);
            Assert.IsNotNull(GBPFromWebAPI.Rates);
            Assert.IsNotNull(GBPFromWebAPI.table);

            Assert.AreEqual(GBPFromWebAPI.code, "GBP");
        }

        // GOLD
        [TestMethod]
        public async System.Threading.Tasks.Task shouldGetGoldCurrencyPeriodofTimeAsync()
        {
            // Given

            // When
            string goldResponseJSON = await clientNBP.getGoldFromPeriodOfTime("2020-03-01", "2020-04-01");

            // Then
            GoldModel [] GoldFromWebAPI = JsonConvert.DeserializeObject<GoldModel[]>(goldResponseJSON);

            Assert.IsNotNull(GoldFromWebAPI);
           

        }

        // FAILUER SCENARIO 

        [TestMethod]
        public async System.Threading.Tasks.Task shouldReturn404ForEUR()
        {
            // Given

            // When
            string eurResponseJSON = await clientNBP.getEURFromPeriodOfTime("2018-03-01", "2020-04-01");

            // Then

            Assert.AreEqual(eurResponseJSON, "Resource not found - 404");
        }

        [TestMethod]
        public async System.Threading.Tasks.Task shouldReturn404ForUSD()
        {
            // Given

            // When
            string usdResponseJSON = await clientNBP.getUSDFromPeriodOfTime("2018-03-01", "2020-04-01");

            // Then

            Assert.AreEqual(usdResponseJSON, "Resource not found - 404");
        }

        [TestMethod]
        public async System.Threading.Tasks.Task shouldReturn404ForGBP()
        {
            // Given

            // When
            string gbpResponseJSON = await clientNBP.getGBPFromPeriodOfTime("2018-03-01", "2020-04-01");

            // Then

            Assert.AreEqual(gbpResponseJSON, "Resource not found - 404");
        }

    } 
}
