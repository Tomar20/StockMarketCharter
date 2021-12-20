using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.DBContext;

namespace StockMarketCharter.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private readonly UserManager<User> userManager;
        private readonly StockMarketCharterDBContext db;
        public EmailController(UserManager<User> userManager, StockMarketCharterDBContext db)
        {
            this.userManager = userManager;
            this.db = db;
            
        }
        [HttpGet]
        [Route("ConfirmEmail")]
        public IActionResult ConfirmEmail(string email, int userId)
        {
            
            Console.WriteLine(email);
          /*  User user = await userManager.FindByEmailAsync(email);*/
            /*User user = await userManager.FindByNameAsync(email);*/
            User user = db.Users.SingleOrDefault(x => x.UserId == userId);
            Console.WriteLine(user);
            if (user != null)
            {
                /*var result = await userManager.ConfirmEmailAsync(user, token);*/
                user.IsEmailConfirmed= true;
                db.SaveChanges();
                /*return Ok(result);*/
                return Ok("EmailConfirmed");
            }

            return BadRequest();
        }

    }
}
