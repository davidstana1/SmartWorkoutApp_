using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User").HasKey(u => u.Id);
        
        builder.Property(u => u.Phone).HasMaxLength(15);
        builder.Property(u => u.Name).IsRequired();
        builder.Property(u => u.Surname).IsRequired();
    }
}