﻿using Microsoft.EntityFrameworkCore;
using WebApplication10.Domain.Models;

namespace WebApplication10.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Student> Students { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(p => p.Id);
            builder.Entity<Country>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().HasMany(p => p.Cities).WithOne(p => p.Country).HasForeignKey(p => p.CountryId);

            builder.Entity<Country>().HasData
            (
                new Country { Id = 1, Name = "Armenia" },
                new Country { Id = 2, Name = "USA" },
                new Country { Id = 3, Name = "France" }

            );

            builder.Entity<City>().ToTable("Cities");
            builder.Entity<City>().HasKey(p => p.Id);
            builder.Entity<City>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<City>().HasMany(p => p.Universities).WithOne(p => p.City).HasForeignKey(p => p.CityId);

            builder.Entity<University>().ToTable("Universities");
            builder.Entity<University>().HasKey(p => p.Id);
            builder.Entity<University>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<University>().HasMany(p => p.Students).WithOne(p => p.University);
            builder.Entity<University>().HasMany(p => p.Lecturers).WithOne(p => p.University);
            builder.Entity<University>().HasMany(p => p.Faculties).WithOne(p => p.University).HasForeignKey(p => p.UniversityId);

            builder.Entity<Faculty>().ToTable("Faculties");
            builder.Entity<Faculty>().HasKey(p => p.Id);
            builder.Entity<Faculty>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Faculty>().HasMany(p => p.Students).WithOne(p => p.Faculty);
            builder.Entity<Faculty>().HasMany(p => p.Lecturers).WithOne(p => p.Faculty);

            builder.Entity<Lecturer>().ToTable("Lecturers");
            builder.Entity<Lecturer>().HasKey(p => p.Id);
            builder.Entity<Lecturer>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<Student>().ToTable("Students");
            builder.Entity<Student>().HasKey(p => p.Id);
            builder.Entity<Student>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
