using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configuration
{
    class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.Property(m => m.Name)
                .IsRequired();

            builder.
                HasOne(m => m.Brand)
                .WithMany(b => b.Models);

            builder.
                HasData(
                new { Name = "A4", BrandId = 1},
                new { Name = "M6", BrandId = 2},
                new { Name = "Punto", BrandId = 3},
                new { Name = "Clio", BrandId = 4},
                new { Name = "Superb", BrandId = 5},
                new { Name = "Golf", BrandId = 6}
                );
        }
    }
}
