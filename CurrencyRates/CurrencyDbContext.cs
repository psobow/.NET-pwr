using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyRates
{
    public sealed class CurrencyDbContext : DbContext
    {
        public DbSet<Rate> rates { get; set; }
        public DbSet<CurrencyModel> currencyModels { get; set; }
        public DbSet<GoldModel> goldModels { get; set; }

        public CurrencyModel findCurrencyByCode(string code)
        {
            return this.currencyModels
                    .Where(currency => currency.code == code)
                    .FirstOrDefault<CurrencyModel>();
        }

        public Rate findCurrencyRateByCodeAndDate(string code, DateTime dateTime)
        {
            var currency = findCurrencyByCode(code);

            if (currency != null)
            {
                return this.rates
                    .Where(rate => rate.effectiveDate.Equals(dateTime) && rate.CurrencyModel.CurrencyModelId == currency.CurrencyModelId)
                    .FirstOrDefault<Rate>();
            }
            else
            {
                return null;
            }
            
        }

        public List<Rate> GetDbRates(string code)
        {

            var currency = findCurrencyByCode(code);
            if (currency != null)
            {
                return this.rates
                  .Where(Rate => Rate.CurrencyModel.CurrencyModelId == currency.CurrencyModelId).ToList();
            }
            else
            {
                return null;
            }
        }

        public List<GoldModel> GetGold()
        {
            return this.goldModels.ToList();
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Rate>()
                    .HasRequired(s => s.CurrencyModel)
                    .WithMany()
                    .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
        */
    }
    
}
