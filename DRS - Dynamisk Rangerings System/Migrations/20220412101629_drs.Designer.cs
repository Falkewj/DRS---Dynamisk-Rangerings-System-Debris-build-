﻿// <auto-generated />
using DRS___Dynamisk_Rangerings_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DRS___Dynamisk_Rangerings_System.Migrations
{
    [DbContext(typeof(DRSDbContext))]
    [Migration("20220412101629_drs")]
    partial class drs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DRS___Dynamisk_Rangerings_System.Models.Participant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LostMatches")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SecondMatches")
                        .HasColumnType("int");

                    b.Property<int>("WonMatches")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}
