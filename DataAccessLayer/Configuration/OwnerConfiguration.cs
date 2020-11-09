using Core.Enums;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Configuration
{
    class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.Property(o => o.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(o => o.City)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(o => o.Street)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(o => o.HouseNumber)
                .IsRequired();

            builder.Property(o => o.Zipcode)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(o => o.Email)
                .HasMaxLength(50);

            builder.Property(o => o.OwnerType)
                .HasConversion(
                v => v.ToString(),
                v => (OwnerEnum)Enum.Parse(typeof(OwnerEnum), v));

            builder.HasData(
                new { Id = 1, Name = "Jelle Schut", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new { Id = 2, Name = "Fred Flintstone", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new { Id = 3, Name = "Sjaak Swart", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new { Id = 4, Name = "Pietje Puk", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new { Id = 5, Name = "Michael Schumacher", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new { Id = 6, Name = "Johan Cruijff", City = "Deventer", Street = "Keizer Frederikstraat", HouseNumber = 77, Zipcode = "7415KC", PhoneNumber = "0657013971", Email = "jelleschut@hotmail.com" },
                new { Id = 7, Name = "SomeCompany", City = "SomeCity", Street = "SomeStreet", HouseNumber = 1, Zipcode = "1234AB" },
                new { Id = 8, Name = "OtherCompany", City = "OtherCity", Street = "OtherStreet", HouseNumber = 1, Zipcode = "4321XZ" },
                new { Id = 9, Name = "ThirdCompany", City = "ThirdCity", Street = "ThirdStreet", HouseNumber = 1, Zipcode = "0987TX" }
                );
        }
    }
}
