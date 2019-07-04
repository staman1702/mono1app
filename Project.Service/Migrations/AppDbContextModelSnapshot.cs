﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Service.Persistence.Contexts;

namespace Project.Service.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Project.Service.Models.VehicleMake", b =>
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

            modelBuilder.Entity("Project.Service.Models.VehicleModel", b =>
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
                            Id = new Guid("35d1d5cc-d8f6-41aa-9a2f-a670a48f6657"),
                            Abrv = "G3",
                            Name = "Golf 3",
                            VehicleMakeId = new Guid("2ca5ebe0-9b49-11e9-b475-0800200c9a66")
                        },
                        new
                        {
                            Id = new Guid("5ee52db2-a1c7-4b4e-9b2f-33006833d379"),
                            Abrv = "X3",
                            Name = "x3",
                            VehicleMakeId = new Guid("0d6ac610-9b49-11e9-b475-0800200c9a66")
                        });
                });

            modelBuilder.Entity("Project.Service.Models.VehicleModel", b =>
                {
                    b.HasOne("Project.Service.Models.VehicleMake", "VehicleMake")
                        .WithMany("VehicleModels")
                        .HasForeignKey("VehicleMakeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}