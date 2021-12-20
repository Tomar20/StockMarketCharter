using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketCharter.StockAPI.DBContext;
using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.Services;

namespace StockMarketCharter.StockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            List<User> users = userService.GetUsers();
            return Ok(users);
        }

        [HttpPut]
        [Route("EditUser")]
        public IActionResult EditUser(User user)
        {
            userService.EditUser(user);
            return Ok("Updated your profile");
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            userService.DeleteUser(user);
            return Ok("User Deleted");
        }
    }
}
