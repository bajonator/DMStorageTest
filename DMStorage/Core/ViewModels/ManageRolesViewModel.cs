using DMStorage.Core.Models.Domains;
using System.Collections.Generic;

namespace DMStorage.Core.ViewModels
{
    public class ManageRolesViewModel
    {
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
    }
}
