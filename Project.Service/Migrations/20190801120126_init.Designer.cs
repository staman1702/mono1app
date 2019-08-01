﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Service.Persistence.Contexts;

namespace Project.Service.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190801120126_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Service.Domain.Models.VehicleMake", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("VehicleMakes");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2ca5ebe0-9b49-11e9-b475-0800200c9a66"),
                            Abrv = "VW",
                            Name = "VolksWagen"
                        },
                        new
                        {
                            Id = new Guid("0d6ac610-9b49-11e9-b475-0800200c9a66"),
                            Abrv = "BMW",
                            Name = "Bmw"
                        });
                });

            modelBuilder.Entity("Project.Service.Domain.Models.VehicleModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abrv")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<Guid>("VehicleMakeId");

                    b.HasKey("Id");

                    b.HasIndex("VehicleMakeId");

                    b.ToTable("VehicleModels");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b4a12a60-9b4c-4b55-b2e0-fe6f7d133890"),
                            Abrv = "G3",
                            Name = "Golf 3",
                            VehicleMakeId = new Guid("2ca5ebe0-9b49-11e9-b475-0800200c9a66")
                        },
                        new
                        {
                            Id = new Guid("99b4ddbc-1038-40e0-9b42-42b6e9d85148"),
                            Abrv = "X3",
                            Name = "x3",
                            VehicleMakeId = new Guid("0d6ac610-9b49-11e9-b475-0800200c9a66")
                        });
                });

            modelBuilder.Entity("Project.Service.Domain.Models.VehicleModel", b =>
                {
                    b.HasOne("Project.Service.Domain.Models.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
