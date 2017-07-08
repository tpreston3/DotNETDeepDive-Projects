using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Resume.Models;

namespace Resume.Migrations
{
    [DbContext(typeof(ResumeContext))]
    partial class ResumeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Resume.Models.Accomplishment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("JobsID");

                    b.HasKey("ID");

                    b.HasIndex("JobsID");

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

            modelBuilder.Entity("Resume.Models.Education", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<int?>("ContactID");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("Graduation");

                    b.Property<string>("InstitutionName");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("State")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("Resume.Models.Employment", b =>
                {
                    b.Property<int>("EmploymentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactID");

                    b.Property<bool?>("Current");

                    b.Property<int?>("JobID");

                    b.HasKey("EmploymentID");

                    b.HasIndex("ContactID");

                    b.ToTable("Employments");
                });

            modelBuilder.Entity("Resume.Models.Job", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployerName")
                        .IsRequired();

                    b.Property<int?>("EmploymentsEmploymentID");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobTitle")
                        .IsRequired();

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("StopDate");

                    b.HasKey("ID");

                    b.HasIndex("EmploymentsEmploymentID");

                    b.ToTable("Job");
                });

            modelBuilder.Entity("Resume.Models.ProfessionalSkill", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int?>("ContactID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("InstitutionName");

                    b.Property<string>("SkillDescription")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("State");

                    b.Property<int?>("ZipCode");

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.ToTable("ProfessionalSkill");
                });

            modelBuilder.Entity("Resume.Models.Reference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContactID");

                    b.Property<string>("EmailAddr");

                    b.Property<string>("Employer")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("JobTitle")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("Relationship")
                        .IsRequired();

                    b.HasKey("ID");

                    b.HasIndex("ContactID");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("Resume.Models.Accomplishment", b =>
                {
                    b.HasOne("Resume.Models.Job", "Jobs")
                        .WithMany("Accomplishments")
                        .HasForeignKey("JobsID");
                });

            modelBuilder.Entity("Resume.Models.Education", b =>
                {
                    b.HasOne("Resume.Models.Contact", "Contact")
                        .WithMany("Educations")
                        .HasForeignKey("ContactID");
                });

            modelBuilder.Entity("Resume.Models.Employment", b =>
                {
                    b.HasOne("Resume.Models.Contact", "Contact")
                        .WithMany("Employments")
                        .HasForeignKey("ContactID");
                });

            modelBuilder.Entity("Resume.Models.Job", b =>
                {
                    b.HasOne("Resume.Models.Employment", "Employments")
                        .WithMany("Jobs")
                        .HasForeignKey("EmploymentsEmploymentID");
                });

            modelBuilder.Entity("Resume.Models.ProfessionalSkill", b =>
                {
                    b.HasOne("Resume.Models.Contact", "Contact")
                        .WithMany("ProfessionalSkills")
                        .HasForeignKey("ContactID");
                });

            modelBuilder.Entity("Resume.Models.Reference", b =>
                {
                    b.HasOne("Resume.Models.Contact", "Contact")
                        .WithMany("References")
                        .HasForeignKey("ContactID");
                });
        }
    }
}
