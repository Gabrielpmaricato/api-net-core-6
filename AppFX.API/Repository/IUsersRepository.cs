using AppFX.API.Models;

namespace AppFX.API.Repository
{
    public interface IUsersRepository
    {
        IQueryable<Users> GetUsers();

        Users GetUser(int id);

        bool UserExists(int id);

        bool UserExists(string username);

        bool CreateUser(Users user);

        bool UpdateUser(Users user);

        bool DeleteUser(Users user);

        bool Save();
    }
}
