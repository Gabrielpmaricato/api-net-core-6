using AppFX.API.EFCore;
using AppFX.API.Models;

namespace AppFX.API.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UsersAppDbContext _db;

        public UsersRepository(UsersAppDbContext db)
        {
            _db = db;
        }

        public bool CreateUser(Users user)
        {
            _db.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(Users user)
        {
            _db.Users.Remove(user);
            return Save();
        }

        public Users GetUser(int id)
        {
            return _db.Users.FirstOrDefault(x => x.IDUser == id);
        }

        public IQueryable<Users> GetUsers()
        {
            return _db.Users.AsQueryable();

        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUser(Users user)
        {
            _db.Users.Update(user);
            return Save();
        }

        public bool UserExists(int id)
        {
            return _db.Users.Any(x => x.IDUser == id);
        }

        public bool UserExists(string username)
        {
            bool value = _db.Users.Any(y => y.Username.ToLower().Trim() == username.ToLower().Trim());
            return value;
        }
    }
}
