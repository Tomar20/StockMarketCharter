using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace StockMarketCharter.AuthAPI.Entities
{
    [Table("Sector")]
    public class Sector
    {
        [Key]
        public string SectorId { get; set; }
        public string SectorName { get; set; }
        public string SectorBrief { get; set; }
    }
}
