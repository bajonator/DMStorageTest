using DMStorage.Core.Models.Domains;
using DMStorage.Persistence;
using System.Collections.Generic;

namespace DMStorage.Core.Service
{
    public interface IAccountService
    {
        List<User> GetUsers();
        Role GetUserForFirstRegister();
        Role GetUserForRegister();
        User GetUserByUserName(string userName);
        User GetUser(int userId = 0);
        List<Role> GetRoles();
        bool UserNameExists(string userName);
        bool UserEmailExists(string email);
        string GetRole(int roleId);
        void AddUser(User model);
        void UpdateUser(int userId, int roleId);
        void DeleteUser(int id);
    }
}
