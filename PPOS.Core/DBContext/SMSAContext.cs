using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Happibook.Core.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Happibook.Core.DBContext
{
    public class HappibookContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserLogin, ApplicationUserRole, IdentityUserClaim>
    {
        public HappibookContext() : base("DefaultConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Audit> Audit { get; set; }

        public DbSet<AuditDetail> AuditDetail { get; set; }
        
       // public DbSet<EmailNotification> EmailNotification { get; set; }
        
        public DbSet<LOV> LOV { get; set; }
        
        public DbSet<Permission> Permission { get; set; }

        public DbSet<UserRolePermission> UserRolePermission { get; set; }

        public DbSet<UserSession> UserSession { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Lisence> Lisence { get; set; }
        
        public DbSet<Setting> Setting { get; set; }

        public DbSet<Currency> Currency { get; set; }

        public DbSet<RoleCategory> RoleCategory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
