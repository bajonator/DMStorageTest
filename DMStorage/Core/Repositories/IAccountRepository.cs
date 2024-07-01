using DMStorage.Core.Models.Domains;
using System.Collections.Generic;

namespace DMStorage.Core.Repositories
{
    public interface IAccountRepository
    {
        List<User> GetUsers();
        Role GetUserForFirstRegister();
        Role GetUserForRegister();
        void AddUser(User model);
        User GetUserByUserName(string userName);
        User GetUser(int userId = 0);
        List<Role> GetRoles();
        void UpdateUser(int userId, int roleId);
        bool UserNameExists(string username);
        bool UserEmailExists(string email);
        string GetRole(int roleId);
        void DeleteUser(int id);
    }
}
