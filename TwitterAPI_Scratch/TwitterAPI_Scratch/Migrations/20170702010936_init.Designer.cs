using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TwitterAPI_Scratch.Models;

namespace TwitterAPI_Scratch.Migrations
{
    [DbContext(typeof(TwitterAPI_ScratchContext))]
    [Migration("20170702010936_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TwitterAPI_Scratch.Models.TwitterAPIAuth", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<string>("AccessTokenSecret");

                    b.Property<string>("BaseURL");

                    b.Property<string>("ConsumerKey");

                    b.Property<string>("ConsumerSecret");

                    b.Property<string>("Owner");

                    b.Property<string>("OwnerID");

                    b.HasKey("ID");

                    b.ToTable("TwitterAPIAuth");
                });
        }
    }
}
