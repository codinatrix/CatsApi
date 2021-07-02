﻿// <auto-generated />
using System;
using Cats.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cats.API.Migrations
{
    [DbContext(typeof(CatApiContext))]
    [Migration("20210701095321_AddTownTableAndAddTownToCats")]
    partial class AddTownTableAndAddTownToCats
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cats.Domain.Entities.Cat", b =>
                {
                    b.Property<Guid>("CatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TownId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CatId");

                    b.HasIndex("TownId");

                    b.ToTable("Cats");
                });

            modelBuilder.Entity("Cats.Domain.Entities.Town", b =>
                {
                    b.Property<Guid>("TownId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TownId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Cats.Domain.Entities.Cat", b =>
                {
                    b.HasOne("Cats.Domain.Entities.Town", "PlaceOfBirth")
                        .WithMany("Cats")
                        .HasForeignKey("TownId");

                    b.Navigation("PlaceOfBirth");
                });

            modelBuilder.Entity("Cats.Domain.Entities.Town", b =>
                {
                    b.Navigation("Cats");
                });
#pragma warning restore 612, 618
        }
    }
}