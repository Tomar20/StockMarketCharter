namespace StockMarketCharter.AuthAPI.Repositories
{
    public interface IEmailRepository
    {
        public bool SendEmail(string email, string confirmationLink);
    }
}
