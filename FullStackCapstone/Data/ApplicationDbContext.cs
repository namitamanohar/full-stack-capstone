using System;
using System.Collections.Generic;
using System.Text;
using FullStackCapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FullStackCapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

    }
       public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Opportunity> Opportunity { get; set; }

        public DbSet<OppCart> OppCart { get; set; }

        public DbSet<ProgramType> ProgramType { get; set; }

        public DbSet<Subject> Subject { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ApplicationUser user = new ApplicationUser
            {
                FirstName = "Admina",
                LastName = "Straytor",
                UserName = "admin@admin.com",
                IsAdmin = true,
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<Subject>().HasData(
               new Subject()
               {
                   Id = 1,
                   Title = "Mathematics"
               },
               new Subject()
               {
                   Id = 2,
                   Title = "Coding"
               },
               new Subject()
               {
                   Id = 3,
                   Title = "Writing"
               },
               new Subject()
               {
                   Id = 4,
                   Title = "Sports"
               },
               new Subject()
               {
                   Id = 5,
                   Title = "Music"
               },
               new Subject()
               {
                   Id = 6,
                   Title = "Science"
               }
           );

            modelBuilder.Entity<ProgramType>().HasData(
               new ProgramType()
               {
                   Id = 1,
                   Title = "Day Program"
               },
               new ProgramType()
               {
                   Id = 2,
                   Title = "Residential Program"
               },
               new ProgramType()
               {
                   Id = 3,
                   Title = "Travel Program"
               }
           );

        }

     }
}
