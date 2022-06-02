using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFramework.Configurations;

public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
{
    public void Configure(EntityTypeBuilder<Officer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
        
        builder.Property(x=> x.Surname).HasMaxLength(50).IsRequired();
        
        builder.Property(x=> x.Birth).HasMaxLength(50);
        
        builder.Property(x=> x.Death).HasMaxLength(50);
        
        builder.Property(x=> x.Kingdom).HasMaxLength(50);
        
        builder.Property(x=> x.Bio).HasMaxLength(5000);
        
        
    }
}