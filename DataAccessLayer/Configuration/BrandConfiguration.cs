using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configuration
{
    class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.BrandId);

            builder.Property(b => b.BrandId)
                .ValueGeneratedOnAdd();

            builder.Property(b => b.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasData(
                   new { BrandId = 1, Name = "Audi" },
                   new { BrandId = 2, Name = "BMW" },
                   new { BrandId = 3, Name = "Fiat" },
                   new { BrandId = 4, Name = "Renault" },
                   new { BrandId = 5, Name = "Skoda" },
                   new { BrandId = 6, Name = "Volkswagen" }
                );
        }
    }
}
