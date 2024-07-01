using DMStorage.Core.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace DMStorage.Core
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Machine> Machines { get; set; }
        DbSet<Variable> Variables { get; set; }
        DbSet<Device> Devices { get; set; }
        DbSet<TypeDevice> TypeDevices { get; set; }

        int SaveChanges();
    }
}
