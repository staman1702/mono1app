using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Service.Models;

namespace Project.Service.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {           
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<VehicleMake>().ToTable("VehicleMakes");
            builder.Entity<VehicleMake>().HasKey(p => p.Id);
            builder.Entity<VehicleMake>().Property(p => p.Id).HasDefaultValueSql("NEWID()");
            builder.Entity<VehicleMake>().Property(p=>p.Id).IsRequired();
            builder.Entity<VehicleMake>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<VehicleMake>().Property(p => p.Abrv).IsRequired().HasMaxLength(15);
            builder.Entity<VehicleMake>().HasMany(p => p.VehicleModels).WithOne(p => p.VehicleMake).HasForeignKey(p => p.VehicleMakeId);

            builder.Entity<VehicleMake>().HasData
                (
                new VehicleMake { Id = Guid.Parse("2ca5ebe0-9b49-11e9-b475-0800200c9a66"), Name = "VolksWagen", Abrv = "VW" },
                new VehicleMake { Id = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66"), Name = "Bmw", Abrv = "BMW" }
                );

            builder.Entity<VehicleModel>().ToTable("VehicleModels");
            builder.Entity<VehicleModel>().HasKey(p => p.Id);
            builder.Entity<VehicleModel>().Property(p => p.Id).IsRequired();
            builder.Entity<VehicleModel>().Property(p => p.Name).IsRequired().HasMaxLength(35);
            builder.Entity<VehicleModel>().Property(p => p.Abrv).IsRequired().HasMaxLength(15);
            builder.Entity<VehicleModel>().Property(p => p.VehicleMakeId).IsRequired();

            builder.Entity<VehicleModel>().HasData
               (
               new VehicleModel { Id = Guid.NewGuid(), Name = "Golf 3", Abrv = "G3", VehicleMakeId = Guid.Parse("2ca5ebe0-9b49-11e9-b475-0800200c9a66") },
               new VehicleModel { Id = Guid.NewGuid(), Name = "x3", Abrv = "X3", VehicleMakeId = Guid.Parse("0d6ac610-9b49-11e9-b475-0800200c9a66") }

               )
               ;

        }
    }
}
