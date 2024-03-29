﻿using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBlog.Infrastructure.DAL.Configurations;

internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .HasConversion(tid => tid.Value, g => new TagId(g));
        builder.Property(t => t.Description)
            .IsRequired()
            .HasConversion(d => d.Value, s => new Description(s));
    }
}
