using CookBlog.Core.Entities;
using CookBlog.Core.ValuesObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBlog.Infrastructure.DAL.Configurations;

internal sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(pid => pid.Value, g => new PostId(g));
        builder.Property(p => p.Title)
            .IsRequired()
            .HasConversion(t => t.Value, s => new Title(s));
        builder.Property(p => p.Description)
            .HasConversion(d => d.Value, s => new Description(s));
    }
}
