using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.ThomasVanMaelePEtwee.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.ThomasVanMaelePEtwee.core.Data.Seeding
{
    public class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();

            // Admin User
            var adminUser = new ApplicationUser
            {
                Id = "1",
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@pri.be",
                UserName = "admin",
                NormalizedEmail = "ADMIN@PRI.BE",
                NormalizedUserName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Test123?")
            };

            // Customer User
            var customerUser = new ApplicationUser
            {
                Id = "2",
                FirstName = "Customer",
                LastName = "User",
                Email = "customer@pri.be",
                UserName = "customer",
                NormalizedEmail = "CUSTOMER@PRI.BE",
                NormalizedUserName = "CUSTOMER",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHasher.HashPassword(null, "Test123?")
            };


            var adminRole = new IdentityRole
            {
                Id = "1",
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };


            var customerRole = new IdentityRole
            {
                Id = "2",
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };


            var adminUserRole = new IdentityUserRole<string>
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };


            var customerUserRole = new IdentityUserRole<string>
            {
                UserId = customerUser.Id,
                RoleId = customerRole.Id
            };
            var quotation = new Quotation
            {
                Id = 1,
                UserId = customerUser.Id,             
                RequestDate = DateTime.UtcNow,
                Status = Enums.QuotationStatus.Pending,
                CustomerComment = "Ik wil de goedkoopste prijs aub"
                
            };

            var swimmingPool = new SwimmingPool
            {
                Id = 1,
                Name = "Pool 1",
                Length = 10.0f,
                Width = 5.0f,
                Depth = 1.5f,
                HasHeating = true,
                QuotationId = quotation.Id
            };

            

            // Add data to the model
            modelBuilder.Entity<ApplicationUser>().HasData(adminUser, customerUser);
            modelBuilder.Entity<IdentityRole>().HasData(adminRole, customerRole);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(adminUserRole, customerUserRole);
            modelBuilder.Entity<Quotation>().HasData(quotation);
            modelBuilder.Entity<SwimmingPool>().HasData(swimmingPool);
        }
    }
}


