﻿// <auto-generated />
using System;
using FullStackCapstone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FullStackCapstone.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200504151147_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FullStackCapstone.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "1804c298-d5c8-4f1c-afb5-bb999c59de28",
                            Email = "admin@admin.com",
                            EmailConfirmed = true,
                            FirstName = "Admina",
                            IsAdmin = true,
                            LastName = "Straytor",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEMyQ3uwXhohCxZ8f0AzbRiTTESAEEtOTCV8Zb67poQhukfMI6/2cA+9xTHaFQCYBOQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.OppCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<int>("OpportunityId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("OpportunityId");

                    b.HasIndex("UserId");

                    b.ToTable("OppCart");
                });

            modelBuilder.Entity("FullStackCapstone.Models.Opportunity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgeRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ApplicationDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProgramTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProgramTypeId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Opportunity");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgeRange = "High School Girls",
                            ApplicationDeadline = new DateTime(2020, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "www.adventuresci.org/twister",
                            Description = "Tennessee Women in Science, Technology, Engineering & Research (TWISTER) is a one day professional conference for high school girls, presented by women working in STEM (science, technology, engineering and research) professions.",
                            EndDate = new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 1,
                            StartDate = new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 7,
                            Title = "TWISTER Conference"
                        },
                        new
                        {
                            Id = 2,
                            AgeRange = "Current High School Juniors",
                            ApplicationDeadline = new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "summerscience.org/the-ssp-experience/what-is-ssp/",
                            Description = "A 39-day residential enrichment program designed to challenge and inspire talented and motivated rising seniors through hands-on research.",
                            EndDate = new DateTime(2020, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 2,
                            StartDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 7,
                            Title = "Summer Science Program"
                        },
                        new
                        {
                            Id = 3,
                            ApplicationDeadline = new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "summer.uchicago.edu/programs/uchicago-summer-scholars",
                            Description = "Being a UChicago Summer Scholar is a great way to get an early look at college-level classes and get a feel for life on campus and in Chicago. You’ll also learn in-depth about the application process for highly selective universities with the guidance of UChicago admissions counselors.",
                            EndDate = new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 2,
                            StartDate = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 8,
                            Title = "UChicago Summer Scholars"
                        },
                        new
                        {
                            Id = 4,
                            AgeRange = "Rising 7th through 12th grade girls",
                            ApplicationDeadline = new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "harpethhall.org/stem-summer-institute-registration",
                            Description = "Girls will participate in a research-based STEM curriculum and use the engineering design process to solve real-world problems.",
                            EndDate = new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 1,
                            StartDate = new DateTime(2020, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 7,
                            Title = "Harpeth Hall STEM Summer Institute"
                        },
                        new
                        {
                            Id = 5,
                            AgeRange = "Rising Junior or Senior Girls",
                            ApplicationDeadline = new DateTime(2020, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "sites.coecis.cornell.edu/curieacademy/",
                            Description = "Curie Academy is a one-week residential program for high school girls who excel in math and science. This summer come to Cornell University and explore the many possibilities awaiting you in engineering.",
                            EndDate = new DateTime(2020, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 2,
                            StartDate = new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 9,
                            Title = "Curie Academy"
                        },
                        new
                        {
                            Id = 6,
                            AgeRange = "Rising Seniors",
                            ApplicationDeadline = new DateTime(2020, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "www.vumc.org/dbmi/summer-research-internship-program-biomedical-informatics",
                            Description = "Provides students from diverse backgrounds with a high quality Biomedical Informatics research experience at Vanderbilt University.",
                            EndDate = new DateTime(2020, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 1,
                            StartDate = new DateTime(2020, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 9,
                            Title = "Summer Research Internship Program"
                        },
                        new
                        {
                            Id = 7,
                            AgeRange = "Girls 16 or 17 years old",
                            ApplicationDeadline = new DateTime(2020, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ApplicationLink = "www.inspiringgirls.org/about-apply",
                            Description = "Inspiring young women through science, art, and wilderness exploration. Apply to join other young girls on unique, one-week long wilderness expeditions.",
                            EndDate = new DateTime(2020, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            ProgramTypeId = 3,
                            StartDate = new DateTime(2020, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SubjectId = 6,
                            Title = "Inspiring Girls Expedition"
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.ProgramType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProgramType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Day Program"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Residential Program"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Travel Program"
                        });
                });

            modelBuilder.Entity("FullStackCapstone.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subject");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Mathematics"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Coding"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Writing"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Sports"
                        },
                        new
                        {
                            Id = 5,
                            Title = "Music"
                        },
                        new
                        {
                            Id = 6,
                            Title = "Science"
                        },
                        new
                        {
                            Id = 7,
                            Title = "STEM"
                        },
                        new
                        {
                            Id = 8,
                            Title = "College Classes"
                        },
                        new
                        {
                            Id = 9,
                            Title = "Math and Science"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FullStackCapstone.Models.OppCart", b =>
                {
                    b.HasOne("FullStackCapstone.Models.Opportunity", "Opportunity")
                        .WithMany()
                        .HasForeignKey("OpportunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("FullStackCapstone.Models.Opportunity", b =>
                {
                    b.HasOne("FullStackCapstone.Models.ProgramType", "ProgramType")
                        .WithMany()
                        .HasForeignKey("ProgramTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FullStackCapstone.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FullStackCapstone.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FullStackCapstone.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FullStackCapstone.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}