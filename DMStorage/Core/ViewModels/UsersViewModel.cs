
using DMStorage.Core.Models.Domains;
using System.Collections.Generic;

namespace DMStorage.Core.ViewModels
{
    public class UsersViewModel
    {
        public User User { get; set; }
        public IEnumerable<ApplicationUser> AppUsers { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
