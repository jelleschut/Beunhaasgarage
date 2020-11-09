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
            builder.Property(b => b.Name)
                .HasMaxLength(40)
                .IsRequired();

            builder.HasData(
                   new { Name = "Audi" },
                   new { Name = "BMW" },
                   new { Name = "Fiat" },
                   new { Name = "Renault" },
                   new { Name = "Skoda" },
                   new { Name = "Volkswagen" }
                );
        }
    }
}
