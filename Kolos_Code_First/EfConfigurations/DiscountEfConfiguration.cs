using Kolos_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos_Code_First.EfConfigurations;

public class DiscountEfConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Discount");
        
        builder.HasKey(d => d.IdDiscount);
        builder.Property(d => d.IdDiscount).ValueGeneratedOnAdd();

        builder.Property(d => d.Value).IsRequired();
        builder.Property(d => d.DateFrom).IsRequired();
        builder.Property(d => d.DateTo).IsRequired();

        builder.HasOne(d => d.IdSubscriptionNavigation)
            .WithMany(s => s.IdDiscountNavigation)
            .HasForeignKey(d => d.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
    }
}