namespace StockMarketCharter.AuthAPI.Services
{
    public interface IEmailService
    {
        bool SendEmail(string email, string confirmationLink);
    }
}
