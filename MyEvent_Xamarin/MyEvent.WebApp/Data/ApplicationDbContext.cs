using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyEvent.WebApp.Models;
using MyEvent.WebApp.Data.Models;

namespace MyEvent.WebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Don't need this; MS apparently didn't fuck it up in EF7
            //modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        public DbSet<MyEvent.WebApp.Data.Models.Event> Event { get; set; }
    }
}
