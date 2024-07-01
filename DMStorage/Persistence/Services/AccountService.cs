using DMStorage.Core;
using DMStorage.Core.Models.Domains;
using DMStorage.Core.Service;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DMStorage.Persistence.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetUsers()
        {
            return _unitOfWork.Account.GetUsers();
        }
        public Role GetUserForFirstRegister()
        {
            return _unitOfWork.Account.GetUserForFirstRegister();
        }
        public Role GetUserForRegister()
        {
            return _unitOfWork.Account.GetUserForRegister();
        }
        public User GetUserByUserName(string userName)
        {
            return _unitOfWork.Account.GetUserByUserName(userName);
        }
        public User GetUser(int userId = 0)
        {
            return _unitOfWork.Account.GetUser(userId);
        }
        public List<Role> GetRoles()
        {
            return _unitOfWork.Account.GetRoles();
        }
        public bool UserNameExists(string userName)
        {
            return _unitOfWork.Account.UserNameExists(userName);
        }
        public bool UserEmailExists(string email)
        {
            return _unitOfWork.Account.UserEmailExists(email);
        }
        public string GetRole(int roleId)
        {
            return _unitOfWork.Account.GetRole(roleId);
        }

        public void AddUser(User model)
        {
            _unitOfWork.Account.AddUser(model);
            _unitOfWork.Complete();
        }
        public void UpdateUser(int userId, int roleId)
        {
            _unitOfWork.Account.UpdateUser(userId, roleId);
            _unitOfWork.Complete();
        }
        public void DeleteUser(int id) 
        {
            _unitOfWork.Account.DeleteUser(id);
            _unitOfWork.Complete();
        }
    }
}
