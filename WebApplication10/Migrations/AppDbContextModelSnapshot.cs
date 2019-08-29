﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication10.Persistence.Context;

namespace WebApplication10.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication10.Domain.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Yerevan"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Gyumri"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "New York"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 2,
                            Name = "Cambridge"
                        });
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Armenia"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "France"
                        });
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Faculty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("UniversityId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Name");

                    b.Property<int?>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Lecturers");
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FacultyId");

                    b.Property<string>("Name");

                    b.Property<int?>("UniversityId");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("UniversityId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Universities");
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.City", b =>
                {
                    b.HasOne("WebApplication10.Domain.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Faculty", b =>
                {
                    b.HasOne("WebApplication10.Domain.Models.University", "University")
                        .WithMany("Faculties")
                        .HasForeignKey("UniversityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Lecturer", b =>
                {
                    b.HasOne("WebApplication10.Domain.Models.Faculty", "Faculty")
                        .WithMany("Lecturers")
                        .HasForeignKey("FacultyId");

                    b.HasOne("WebApplication10.Domain.Models.University", "University")
                        .WithMany("Lecturers")
                        .HasForeignKey("UniversityId");
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.Student", b =>
                {
                    b.HasOne("WebApplication10.Domain.Models.Faculty", "Faculty")
                        .WithMany("Students")
                        .HasForeignKey("FacultyId");

                    b.HasOne("WebApplication10.Domain.Models.University", "University")
                        .WithMany("Students")
                        .HasForeignKey("UniversityId");
                });

            modelBuilder.Entity("WebApplication10.Domain.Models.University", b =>
                {
                    b.HasOne("WebApplication10.Domain.Models.City", "City")
                        .WithMany("Universities")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
