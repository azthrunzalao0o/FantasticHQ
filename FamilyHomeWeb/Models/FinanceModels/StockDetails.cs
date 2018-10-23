namespace FamilyHomeWeb.Models.FinanceModels
{
    public class StockDetails
    {
        public string StockCode { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public double MarketChanges { get; set; }
    }
}