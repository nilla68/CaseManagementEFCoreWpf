using CaseManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace CaseManagement.Data
{
    internal class CaseManagementDbContext : DbContext
    {
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Case> Cases => Set<Case>();
        public DbSet<Address> Addresses => Set<Address>();

        public CaseManagementDbContext()
        {
        }

        public CaseManagementDbContext(DbContextOptions<CaseManagementDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\GitHub\CaseManagementEFCoreWpf\CaseManagement\Data\CaseManagement.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}