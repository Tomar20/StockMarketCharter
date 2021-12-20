using System.Net;
using System.Net.Mail;
using StockMarketCharter.AuthAPI.Repositories;

namespace StockMarketCharter.AuthAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly IEmailRepository emailRepository;

        public EmailService(IEmailRepository emailRepository)
        {
            this.emailRepository = emailRepository;
        }

        public bool SendEmail(string email, string confirmationLink)
        { 

            try
            {
                emailRepository.SendEmail(email, confirmationLink);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
