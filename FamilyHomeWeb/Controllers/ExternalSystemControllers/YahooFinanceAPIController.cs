using FamilyHomeWeb.Models.FinanceModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace FamilyHomeWeb.Controllers.ExternalSystemControllers
{
    public class YahooFinanceAPIController : IDisposable
    {
        public YahooStockModel GetStockDetails()
        {
            try
            {
                StockDetails[] stocks = new StockDetails[2];
                Task<IReadOnlyDictionary<string, Security>> task = Yahoo.Symbols("FOLD", "GOOG").Fields(Field.Symbol, Field.LongName, Field.RegularMarketPrice, Field.RegularMarketChangePercent).QueryAsync();
                IReadOnlyDictionary<string, Security> results = task.Result;
                int index = 0;
                foreach (Security security in results.Values)
                {
                    StockDetails stock = new StockDetails()
                    {
                        StockCode = security[Field.Symbol],
                        Description = security[Field.LongName],
                        CurrentPrice = security[Field.RegularMarketPrice],
                        MarketChanges = security[Field.RegularMarketChangePercent]
                    };
                    stocks[index] = stock;
                    index++;
                }
                return new YahooStockModel() { Stocks = stocks };
            }
            catch
            {
                throw new WebException(@"There is an ERROR using Yahoo Finance API.");
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~YahooFinanceAPI() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}