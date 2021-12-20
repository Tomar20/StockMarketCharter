using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Services
{
    public interface IUserService
    {
        List<User> GetUsers();
        void EditUser(User user);

        void DeleteUser(User user);
    }
}
