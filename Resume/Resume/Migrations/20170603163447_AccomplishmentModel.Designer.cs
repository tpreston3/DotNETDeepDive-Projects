using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Resume.Models;

namespace Resume.Migrations
{
    [DbContext(typeof(ResumeContext))]
    [Migration("20170603163447_AccomplishmentModel")]
    partial class AccomplishmentModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resume.Models.Accomplishment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AccomplishmentID");

                    b.Property<int?>("JobID");

                    b.Property<string>("accomplishment")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("AccomplishmentID");

                    b.ToTable("Accomplishment");
                });

            modelBuilder.Entity("Resume.Models.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("EmailAddr");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired();

                    b.Property<int>("StreetNumber");

                    b.Property<string>("Website");

                    b.Property<int>("ZipCode");

                    b.HasKey("ID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Resume.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployerName")
                        .IsRequired();

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobTitle")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StopDate");

                    b.HasKey("ID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Resume.Models.Accomplishment", b =>
                {
                    b.HasOne("Resume.Models.Accomplishment")
                        .WithMany("Accomplishments")
                        .HasForeignKey("AccomplishmentID");
                });
        }
    }
}
