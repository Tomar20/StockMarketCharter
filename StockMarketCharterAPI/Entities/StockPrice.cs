using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockMarketCharter.AuthAPI.Entities
{
    [Table("Stock Price")]
    public class StockPrice
    {
        [Key]
        public string StockCode { get; set;}

        [ForeignKey("StockExchange")]
        public string StockExchangeId { get; set; }

        public int CurrentPrice { get; set; }

        /*        [Column(TypeName = "Date")]
                [DataType(DataType.Date)]
                public DateTime Date { get; set; }

                [DataType(DataType.Time)]
                public TimeSpan Time { get; set; }*/

        public DateTime DateTime { get; set; }

        public StockExchange? StockExchange { get; set; }


    }
}
