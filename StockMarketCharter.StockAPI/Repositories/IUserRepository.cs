using StockMarketCharter.StockAPI.Entities;
namespace StockMarketCharter.StockAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        void EditUser(User user);

        void DeleteUser(User user);
    }
}
