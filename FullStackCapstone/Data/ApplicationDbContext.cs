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

            modelBuilder.Entity<Opportunity>().HasData(
                new Opportunity()
                {
                    Id = 1, 
                    Title = "TWISTER Conference", 
                    Description = "Tennessee Women in Science, Technology, Engineering & Research (TWISTER) is a one day professional conference for high school girls, presented by women working in STEM (science, technology, engineering and research) professions.", 
                    StartDate = new DateTime(2020, 06, 14),
                    EndDate = new DateTime (2020, 06, 14), 
                    ApplicationDeadline = new DateTime (2020, 05, 28),
                    IsActive = true, 
                    ApplicationLink = "www.adventuresci.org/twister", 
                    AgeRange = "High School Girls", 
                    SubjectId = 7, 
                    ProgramTypeId = 1
                }, 
                new Opportunity()
                {
                    Id = 2, 
                    Title = "Summer Science Program", 
                    Description = "A 39-day residential enrichment program designed to challenge and inspire talented and motivated rising seniors through hands-on research.", 
                    StartDate = new DateTime (2020, 06, 01), 
                    EndDate = new DateTime (2020, 07, 09), 
                    ApplicationDeadline = new DateTime (2020, 05, 22),
                    IsActive = true, 
                    ApplicationLink = "summerscience.org/the-ssp-experience/what-is-ssp/", 
                    AgeRange = "Current High School Juniors", 
                    SubjectId = 7, 
                    ProgramTypeId = 2
                }, 
                new Opportunity()
                {
                    Id = 3, 
                    Title = "UChicago Summer Scholars", 
                    Description = "Being a UChicago Summer Scholar is a great way to get an early look at college-level classes and get a feel for life on campus and in Chicago. You’ll also learn in-depth about the application process for highly selective universities with the guidance of UChicago admissions counselors.", 
                    StartDate = new DateTime (2020, 07, 12), 
                    EndDate = new DateTime (2020, 07, 31),
                    ApplicationDeadline = new DateTime(2020, 05, 24),
                    IsActive = true, 
                    ApplicationLink = "summer.uchicago.edu/programs/uchicago-summer-scholars", 
                    SubjectId = 8, 
                    ProgramTypeId = 2
                }, 
                new Opportunity()
                {
                    Id = 4, 
                    Title = "Harpeth Hall STEM Summer Institute", 
                    Description = "Girls will participate in a research-based STEM curriculum and use the engineering design process to solve real-world problems.", 
                    StartDate = new DateTime(2020, 06, 01), 
                    EndDate = new DateTime(2020, 06, 12),
                    ApplicationDeadline = new DateTime(2020, 05, 24),
                    IsActive = true, 
                    ApplicationLink = "harpethhall.org/stem-summer-institute-registration", 
                    SubjectId = 7, 
                    ProgramTypeId = 1, 
                    AgeRange = "Rising 7th through 12th grade girls"

                }, 
                new Opportunity()
                {
                    Id = 5, 
                    Title = "Curie Academy", 
                    Description = "Curie Academy is a one-week residential program for high school girls who excel in math and science. This summer come to Cornell University and explore the many possibilities awaiting you in engineering.", 
                    StartDate = new DateTime(2020, 07, 12), 
                    EndDate = new DateTime(2020, 07, 18), 
                    ApplicationDeadline = new DateTime (2020, 06, 02), 
                    IsActive = true, 
                    ApplicationLink = "sites.coecis.cornell.edu/curieacademy/", 
                    SubjectId = 9, 
                    ProgramTypeId = 2, 
                    AgeRange = "Rising Junior or Senior Girls", 
                }, 
                new Opportunity()
                {
                    Id = 6, 
                    Title = "Summer Research Internship Program", 
                    Description = "Provides students from diverse backgrounds with a high quality Biomedical Informatics research experience at Vanderbilt University.", 
                    StartDate = new DateTime(2020, 05, 27), 
                    EndDate = new DateTime(2020, 07, 31), 
                    ApplicationDeadline = new DateTime(2020, 05, 15), 
                    AgeRange = "Rising Seniors", 
                    IsActive = true, 
                    ApplicationLink = "www.vumc.org/dbmi/summer-research-internship-program-biomedical-informatics", 
                    SubjectId = 9, 
                    ProgramTypeId = 1
                }, 
                new Opportunity()
                {
                    Id = 7, 
                    Title = "Inspiring Girls Expedition",
                    Description = "Inspiring young women through science, art, and wilderness exploration. Apply to join other young girls on unique, one-week long wilderness expeditions.", 
                    StartDate = new DateTime (2020, 07, 01 ), 
                    EndDate = new DateTime (2020, 07, 21), 
                    ApplicationDeadline = new DateTime (2020, 06, 25), 
                    IsActive = true, 
                    ApplicationLink = "www.inspiringgirls.org/about-apply", 
                    AgeRange = "Girls 16 or 17 years old", 
                    SubjectId = 6, 
                    ProgramTypeId = 3

                }

                ); 
            


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
               }, 
               new Subject()
               {
                   Id = 7, 
                   Title = "STEM"
               }, 
               new Subject()
               {
                   Id = 8, 
                   Title = "College Classes"
               }, 
               new Subject()
               {
                   Id = 9, 
                   Title = "Math and Science"
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
