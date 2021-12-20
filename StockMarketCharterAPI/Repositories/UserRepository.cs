using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.Models;
using StockMarketCharter.AuthAPI.DBContext;
using Microsoft.AspNetCore.Identity;

namespace StockMarketCharter.AuthAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockMarketCharterDBContext db;
        private readonly UserManager<User> userManager;
       /* private readonly IEmailService emailService;*/

        public UserRepository(StockMarketCharterDBContext context, UserManager<User> userManager)
        {
            this.db = context;
            this.userManager = userManager;
            /*this.emailService = emailService;*/

        }
        public User Login(Login login)
        {
            try
            {
                return db.Users.SingleOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(User user)
        {
            try
            {
                db.Users.Add(user);
                db.SaveChanges();
                /*var currUser = new IdentityUser
                {
                    Email = user.Email

                };
                var token = await userManager.GenerateEmailConfirmationTokenAsync(currUser);
                string bodyMessage = "Click here to confirm your mail id" + token;
                HttpRequest request = url.ActionContext.HttpContext.Request;
                var confirmationLink = @Url.Action("ConfirmEmail", "Email", new { token, email = user.Email }, Request.Scheme);
                *//*EmailService emailHelper = new EmailSerivce();*/
                /*var requestContext = HttpContext.Current.Request.RequestContext;
                new UrlHelper(requestContext).Action("Index", "MainPage");*//*
                bool emailResponse = emailService.SendEmail(user.Email, bodyMessage);
                Console.WriteLine(emailResponse);
                *//*db.SaveChanges(user.IsEmailConfirmed = emailResponse);*/
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
