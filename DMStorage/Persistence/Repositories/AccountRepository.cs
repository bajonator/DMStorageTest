using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DMStorage.Persistence.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private IApplicationDbContext _context;
        public AccountRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public Role GetUserForFirstRegister()
        {
            var user = _context.Roles.SingleOrDefault(x => x.Name == "FiOT");
            return user;
        }
        public Role GetUserForRegister()
        {
            var user = _context.Roles.SingleOrDefault(x => x.Name == "User");
            return user;
        }

        public void AddUser(User model)
        {
            _context.Users.Add(model);
            _context.SaveChanges();
        }

        public User GetUserByUserName(string userName)
        {
            var user = _context.Users.Include(u => u.Role)
               .FirstOrDefault(u => u.Username == userName);
            return user;
        }
        public User GetUser(int userId = 0)
        {
            var user = _context.Users.Find(userId);
            return user;
        }
        public List<Role> GetRoles()
        {
            return _context.Roles.ToList();
        }

        public void UpdateUser(int userId, int roleId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            user.RoleId = roleId;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public bool UserNameExists(string username)
        {
            return _context.Users.Any(x => x.Username == username);
        }

        public bool UserEmailExists(string email)
        {
            return _context.Users.Any(x => x.Email == email);
        }

        public string GetRole(int roleId)
        {
            var role = _context.Roles.FirstOrDefault(x => x.Id == roleId);
            var roleName = role.Name;
            return roleName;
        }

        public void DeleteUser(int id)
        {
            var UserToDelete = _context.Users.FirstOrDefault(x => x.Id == id);

            _context.Users.Remove(UserToDelete);
            _context.SaveChanges();
        }
    }
}
