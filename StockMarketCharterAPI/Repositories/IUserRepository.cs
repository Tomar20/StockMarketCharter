using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.Models;

namespace StockMarketCharter.AuthAPI.Repositories
{
    public interface IUserRepository
    {
        void Register(User user);
        User Login(Login login);
    }
}
