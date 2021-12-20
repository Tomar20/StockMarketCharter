using System.Net;
using System.Net.Mail;

namespace StockMarketCharter.AuthAPI.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        public bool SendEmail(string email, string confirmationLink)
        {
            try
            {
                string fromMail = "rahulstomar2021@gmail.com";
                string fromPassword = "dyouxeyhxbfqmydj";

                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress(fromMail);
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.Subject = "Confirm Your Mail";
                mailMessage.Body = confirmationLink;
                mailMessage.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                try
                {
                    smtpClient.Send(mailMessage);
                    return true;
                }
                catch (Exception)
                {
                    throw;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
