using System.Data.Entity;
using BillingManagement.Database.Models;

namespace BillingManagement.Database.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Billing> Billings { get; set; }

        public DatabaseContext() : base("name=BillingManagement") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            System.Data.Entity.Database.SetInitializer<DatabaseContext>(null);
        }
    }
}
