using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using YelpAPI.Models;

namespace YelpAPI.Migrations
{
    [DbContext(typeof(YelpAPIContext))]
    [Migration("20170701202703_NextUpdate")]
    partial class NextUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YelpAPI.Models.YelpAuthToken", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("access_token");

                    b.Property<DateTime>("expire_date");

                    b.Property<string>("token_type");

                    b.HasKey("ID");

                    b.ToTable("YelpAuthToken");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Location");

                    b.Property<string>("Term");

                    b.HasKey("ID");

                    b.ToTable("YelpSearch");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RegionID");

                    b.Property<int>("total");

                    b.HasKey("ID");

                    b.HasIndex("RegionID");

                    b.ToTable("YelpSearchResult");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Business", b =>
                {
                    b.Property<int>("BusinessID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CoordinatesID");

                    b.Property<int?>("LocationID");

                    b.Property<int?>("YelpSearchResultID");

                    b.Property<double>("distance");

                    b.Property<string>("id");

                    b.Property<string>("image_url");

                    b.Property<bool>("is_closed");

                    b.Property<string>("name");

                    b.Property<string>("phone");

                    b.Property<string>("price");

                    b.Property<int>("rating");

                    b.Property<int>("review_count");

                    b.Property<string>("url");

                    b.HasKey("BusinessID");

                    b.HasIndex("CoordinatesID");

                    b.HasIndex("LocationID");

                    b.HasIndex("YelpSearchResultID");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BusinessID");

                    b.Property<string>("alias");

                    b.Property<string>("title");

                    b.HasKey("CategoryID");

                    b.HasIndex("BusinessID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Center", b =>
                {
                    b.Property<int>("CenterID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("latitude");

                    b.Property<double>("longitude");

                    b.HasKey("CenterID");

                    b.ToTable("Center");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Coordinates", b =>
                {
                    b.Property<int>("CoordinatesID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("latitude");

                    b.Property<double>("longitude");

                    b.HasKey("CoordinatesID");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("address1");

                    b.Property<string>("address2");

                    b.Property<string>("address3");

                    b.Property<string>("city");

                    b.Property<string>("country");

                    b.Property<string>("state");

                    b.Property<string>("zip_code");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Region", b =>
                {
                    b.Property<int>("RegionID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CenterID");

                    b.HasKey("RegionID");

                    b.HasIndex("CenterID");

                    b.ToTable("Region");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult", b =>
                {
                    b.HasOne("YelpAPI.Models.YelpSearchResult+Region", "region")
                        .WithMany()
                        .HasForeignKey("RegionID");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Business", b =>
                {
                    b.HasOne("YelpAPI.Models.YelpSearchResult+Coordinates", "coordinates")
                        .WithMany()
                        .HasForeignKey("CoordinatesID");

                    b.HasOne("YelpAPI.Models.YelpSearchResult+Location", "location")
                        .WithMany()
                        .HasForeignKey("LocationID");

                    b.HasOne("YelpAPI.Models.YelpSearchResult")
                        .WithMany("businesses")
                        .HasForeignKey("YelpSearchResultID");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Category", b =>
                {
                    b.HasOne("YelpAPI.Models.YelpSearchResult+Business")
                        .WithMany("categories")
                        .HasForeignKey("BusinessID");
                });

            modelBuilder.Entity("YelpAPI.Models.YelpSearchResult+Region", b =>
                {
                    b.HasOne("YelpAPI.Models.YelpSearchResult+Center", "center")
                        .WithMany()
                        .HasForeignKey("CenterID");
                });
        }
    }
}
