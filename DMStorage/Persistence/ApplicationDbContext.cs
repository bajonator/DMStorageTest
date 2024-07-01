using Microsoft.EntityFrameworkCore;
using DMStorage.Core.Models;
using DMStorage.Core.Models.Domains;
using DMStorage.Core;

namespace DMStorage.Data
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<TypeDevice> TypeDevices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Machine)
                .WithMany(m => m.Devices)
                .HasForeignKey(d => d.MachineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.Department)
                .WithMany(dep => dep.Devices)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Device>()
                .HasOne(d => d.TypeDevice)
                .WithMany(td => td.Devices)
                .HasForeignKey(d => d.TypeDeviceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}