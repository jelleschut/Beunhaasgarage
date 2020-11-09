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
                .WithMany(c => c.MaintenanceSpecifications);

            builder.HasData(
                new { Date = DateTime.Now, Milage = 1234567890, Description = "Reparatie", Type = MaintenanceTypeEnum.REPAIR, CarId = 1 },
                new { Date = DateTime.Now, Milage = 1234567890, Description = "Reparatie", Type = MaintenanceTypeEnum.REPAIR, CarId = 2 },
                new { Date = DateTime.Now, Milage = 1234567890, Description = "Reparatie", Type = MaintenanceTypeEnum.REPAIR, CarId = 3 }, 
                new { Date = DateTime.Now, Milage = 1234567890, Description = "APK", Type = MaintenanceTypeEnum.MOT, CarId = 4, Id = 4 },
                new { Date = DateTime.Now, Milage = 1234567890, Description = "APK", Type = MaintenanceTypeEnum.MOT, CarId = 5, Id = 5 },
                new { Date = DateTime.Now, Milage = 1234567890, Description = "APK", Type = MaintenanceTypeEnum.MOT, CarId = 6, Id = 6 }
                );
        }
    }
}
