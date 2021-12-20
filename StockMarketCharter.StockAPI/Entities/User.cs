using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace StockMarketCharter.StockAPI.Entities
{
    [Table("User")]
    public class User : IdentityUser
    {
        [Key]
        public int UserId { get; set; }

        public override string? UserName { get; set; }

        public string? Password { get; set; }

        public override string? Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string? Mobile { get; set; }
        public string? Role  { get; set; }

    }
}
