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

        // GBP

        // GOLD



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

        // GBP

        // GOLD


        // FAILURE SCCENARIO
        //EUR
        [TestMethod]
        public async System.Threading.Tasks.Task shouldReturn404ForEuro()
        {
            // Given

            // When
            string eurResponseJSON = await clientNBP.getEURFromPeriodOfTime("2018-03-01", "2020-04-01");

            // Then
            Assert.AreEqual(eurResponseJSON, "Resource not found - 404");
        }


    }
}
