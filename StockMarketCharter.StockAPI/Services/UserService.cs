using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.Repositories;


namespace StockMarketCharter.StockAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository=userRepository;
        }

        public void DeleteUser(User user)
        {
            try
            {
                userRepository.DeleteUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditUser(User user)
        {
            try
            {
                userRepository.EditUser(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return userRepository.GetUsers();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
