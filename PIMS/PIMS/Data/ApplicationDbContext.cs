using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using PIMS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIMS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
namespace LoginRegister
{
    public class DataContext : IdentityDbContext<IdentityUser, IdentityRole, string, IdentityUserClaim<string>, IdentityUserRole<string>,
     IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser>();
        }
    }
}

namespace PIMS.Data
{
    public partial class RoleContext : DbContext
    {
        public RoleContext()
        { }
        public virtual DbSet<RoleMod> Roles
        {
            get; set;
        }
        public RoleContext(DbContextOptions<RoleContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=uahserver.database.windows.net;Initial Catalog=PIMS;Persist Security Info=True;User ID=uahdev;Password=Ci2M%DU3p8^HX5x3@$");
        }
    }
}