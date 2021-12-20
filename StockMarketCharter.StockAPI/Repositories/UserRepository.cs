using StockMarketCharter.StockAPI.Entities;
using StockMarketCharter.StockAPI.DBContext;

namespace StockMarketCharter.StockAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockMarketCharterDBContext db;
        public UserRepository(StockMarketCharterDBContext db)
        {
            this.db = db;
        }

        public void DeleteUser(User user)
        {
            try
            {
                db.Users.Remove(user);
                db.SaveChanges();
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
                db.Users.Update(user);
                db.SaveChanges();
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
                return db.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
