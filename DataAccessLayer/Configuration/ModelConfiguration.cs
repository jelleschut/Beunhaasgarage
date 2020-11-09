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
            builder.Property(m => m.ModelId)
                .ValueGeneratedOnAdd();

            builder.Property(m => m.Name)
                .IsRequired();

            builder.
                HasOne(m => m.Brand)
                .WithMany(b => b.Models);

            builder.
                HasData(
                new { ModelId = 1, Name = "A4", BrandId = 1},
                new { ModelId = 2, Name = "M6", BrandId = 2},
                new { ModelId = 3, Name = "Punto", BrandId = 3},
                new { ModelId = 4, Name = "Clio", BrandId = 4},
                new { ModelId = 5, Name = "Superb", BrandId = 5},
                new { ModelId = 6, Name = "Golf", BrandId = 6}
                );
        }
    }
}
