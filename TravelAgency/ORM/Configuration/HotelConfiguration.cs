﻿// <copyright file="HotelConfiguration.cs" company="Самофалов А.П.">
// Copyright (c) Самофалов А.П.. All rights reserved.
// </copyright>

namespace ORM.Configuration
{
    using Domain;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HotelConfiguration:IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.NameHotel)
                .IsRequired();
            builder.Property(h => h.ClassHotel)
                .IsRequired();

            builder
                .HasMany(h => h.Tours)
                .WithMany(t => t.Hotels);

            builder
                .HasOne(h => h.Country)
                .WithMany(c => c.Hotels)
                .HasForeignKey("CountryId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}