using StockMarketCharter.AuthAPI.Entities;
using StockMarketCharter.AuthAPI.Models;
using StockMarketCharter.AuthAPI.Repositories;
namespace StockMarketCharter.AuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public User Login(Login login)
        {
            try
            {
                return repository.Login(login);
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
                repository.Register(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
