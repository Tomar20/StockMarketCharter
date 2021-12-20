namespace StockMarketCharter.ReadExcelAPI.Models
{
    public class StockPrice
    {
        public string StockCode { get; set; }

        public string StockExchangeId { get; set; }

        public int CurrentPrice { get; set; }

        public DateTime DateTime  { get; set; }

    }
}
