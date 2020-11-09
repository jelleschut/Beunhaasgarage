using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configuration
{
    class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.Property(c => c.LicenseNumber)
                .HasMaxLength(8)
                .IsRequired();

            builder.Property(c => c.Status)
                .HasConversion(
                v => v.ToString(),
                v => (StatusEnum)Enum.Parse(typeof(StatusEnum), v));

            builder
                .HasOne(c => c.Brand)
                .WithMany(b => b.Cars);

            builder
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars);

            builder
                .HasOne(c => c.Owner)
                .WithMany(o => o.Cars);

            builder
                .HasOne(ca => ca.Customer)
                .WithMany(cu => cu.Cars);

            builder.HasData(
                new { CarId = 1, LicenseNumber = "1-ABC-23", Status = StatusEnum.REGISTERED, BrandId = 1, ModelId = 1, OwnerId = 1, CustomerId = 1 },
                new { CarId = 2, LicenseNumber = "9-ZYX-87", Status = StatusEnum.REGISTERED, BrandId = 2, ModelId = 2, OwnerId = 2, CustomerId = 2 },
                new { CarId = 3, LicenseNumber = "6-XXX-66", Status = StatusEnum.REGISTERED, BrandId = 3, ModelId = 3, OwnerId = 3, CustomerId = 3 },
                new { CarId = 4, LicenseNumber = "AB-CD-12", Status = StatusEnum.REGISTERED, BrandId = 4, ModelId = 4, OwnerId = 7, CustomerId = 4 },
                new { CarId = 5, LicenseNumber = "98-ZY-XW", Status = StatusEnum.REGISTERED, BrandId = 5, ModelId = 5, OwnerId = 8, CustomerId = 5 },
                new { CarId = 6, LicenseNumber = "XD-XD-88", Status = StatusEnum.REGISTERED, BrandId = 6, ModelId = 6, OwnerId = 9, CustomerId = 6 }
                );
        }
    }
}
