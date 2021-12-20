/*using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using StockMarketCharter.AuthAPI.Entities;

namespace StockMarketCharter.AuthAPI.Controllers
{
    public class Econtroller : Controller
    {
        private UserManager<User> userManager;
        public Econtroller(UserManager<User> usrMgr)
        {
            userManager = usrMgr;
        }

        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            Console.WriteLine(email);
            IdentityUser user = await userManager.FindByEmailAsync(email);
            Console.WriteLine(user);
            if (user != null)
            {
                var result = await userManager.ConfirmEmailAsync(user, token);
                user.EmailConfirmed= true;
                return Ok(result);
            }
            return View();
           *//* return BadRequest();
            return View(result.Succeeded ? "ConfirmEmail" : "Error");*//*
        }
    }
}
*/