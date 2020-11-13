using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configuration
{
    class MaintenanceSpecificationConfiguration : IEntityTypeConfiguration<MaintenanceSpecification>
    {
        public void Configure(EntityTypeBuilder<MaintenanceSpecification> builder)
        {
            builder.HasKey(ms => ms.MaintenanceSpecificationId);

            builder.Property(ms => ms.MaintenanceSpecificationId)
                .ValueGeneratedOnAdd();

            builder.Property(ms => ms.Date)
                .IsRequired();

            builder.Property(ms => ms.Milage)
                .IsRequired();

            builder.Property(ms => ms.MaintenanceType)
                .IsRequired();

            builder.Property(ms => ms.MaintenanceType)
                .HasConversion(
                v => v.ToString(),
                v => (MaintenanceTypeEnum)Enum.Parse(typeof(MaintenanceTypeEnum), v));

            builder.HasOne(ms => ms.Car)
                .WithMany(c => c.MaintenanceSpecifications)
                .IsRequired();

            builder.HasData(
                new { MaintenanceSpecificationId = 1, Date = DateTime.Now, Milage = 1234567890, Description = "Reparatie", MaintenanceType = MaintenanceTypeEnum.REPAIR, CarId = 1 },
                new { MaintenanceSpecificationId = 2, Date = DateTime.Now, Milage = 1234567890, Description = "Reparatie", MaintenanceType = MaintenanceTypeEnum.REPAIR, CarId = 2 },
                new { MaintenanceSpecificationId = 3, Date = DateTime.Now, Milage = 1234567890, Description = "Reparatie", MaintenanceType = MaintenanceTypeEnum.REPAIR, CarId = 3 }, 
                new { MaintenanceSpecificationId = 4, Date = DateTime.Now, Milage = 1234567890, Description = "APK", MaintenanceType = MaintenanceTypeEnum.MOT, CarId = 4, Id = 4 },
                new { MaintenanceSpecificationId = 5, Date = DateTime.Now, Milage = 1234567890, Description = "APK", MaintenanceType = MaintenanceTypeEnum.MOT, CarId = 5, Id = 5 },
                new { MaintenanceSpecificationId = 6, Date = DateTime.Now, Milage = 1234567890, Description = "APK", MaintenanceType = MaintenanceTypeEnum.MOT, CarId = 6, Id = 6 }
                );
        }
    }
}
