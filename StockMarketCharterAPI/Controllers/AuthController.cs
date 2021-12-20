using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.Models;
using StockMarketCharter.AuthAPI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockMarketCharter.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;

        private readonly IEmailService emailService;
   

        public AuthController(IUserService userService, UserManager<User> userManager, IEmailService emailService)
        {
            this.userService = userService;
            this.userManager=userManager;
            this.emailService=emailService;
            
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                userService.Register(user);
                /*var registeringUser = new User {  UserName = user.UserName, Email = user.Email };
                var result = await userManager.CreateAsync(registeringUser, user.Password);*/

                /*if (result.Succeeded)
                {
                    var currUser = new User
                    {
                        Email = user.Email

                    };
                    *//*await signInManager.SignInAsync(registeringUser, isPersistent: false);*//*
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(currUser);
                    *//*string bodyMessage = "Click here to confirm your mail id" + token;*//*
                    var confirmationLink = Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                    bool emailResponse = emailService.SendEmail(user.Email, confirmationLink);
                    Console.WriteLine(emailResponse);
                }*/

                var currUser = new User
                {
                    Email = user.Email

                };
                var token = await userManager.GenerateEmailConfirmationTokenAsync(currUser);
               /* string bodyMessage = "Click here to confirm your mail id" + token;*/
                var confirmationLink = Url.Action("ConfirmEmail", "Email", new { email = user.Email, userId = user.UserId }, Request.Scheme);
                bool emailResponse = emailService.SendEmail(user.Email, confirmationLink);
                Console.WriteLine(emailResponse);

                return Ok();
            }
            catch (Exception ex)
            {            
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            try
            {
                AuthUser authUser = null;
                User user = userService.Login(login);
                if (user != null)
                {
                    /*authUser = new AuthUser()
                    {
                        UserId = user.UserId,
                        Token = GetToken(user),
                        Role = user.Role
                    };*/
                    authUser = new AuthUser();
                    authUser.Role = user.Role;
                    authUser.UserId = user.UserId;
                    authUser.Token = GetToken(user);
                }

                return Ok(authUser);

            }
            catch (Exception ex)
            {
                //_logger.LogInformation(ex.Message);
                return NotFound(ex.Message);

            }
        }

        private string GetToken(User user)
        {
            var _config = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json").Build();
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
        (securityKey, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                   {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                   }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
