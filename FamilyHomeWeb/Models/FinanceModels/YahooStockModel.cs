using System;

namespace FamilyHomeWeb.Models.FinanceModels
{
    public class YahooStockModel
    {
        public StockDetails[] Stocks { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public bool HasAPIError { get; set; } = false;
        public string ErrorMessage { get; set; }
    }
}