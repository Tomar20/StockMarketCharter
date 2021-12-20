using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.Models;

namespace StockMarketCharter.AuthAPI.Services
{
    public interface IUserService
    {
        void Register(User user);
        User Login(Login login);
    }
}
