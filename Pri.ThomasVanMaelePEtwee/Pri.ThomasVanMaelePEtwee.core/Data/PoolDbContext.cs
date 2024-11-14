using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pri.ThomasVanMaelePEtwee.core.Data.Seeding;
using Pri.ThomasVanMaelePEtwee.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Data
{
    public class PoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<SwimmingPool> SwimmingPools { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public PoolDbContext(DbContextOptions<PoolDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                
        
            base.OnModelCreating(modelBuilder);
            DataSeeder.Seed(modelBuilder);
        }

    }
}
