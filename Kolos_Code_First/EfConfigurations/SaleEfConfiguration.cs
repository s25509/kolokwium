using Kolos_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos_Code_First.EfConfigurations;

public class SaleEfConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");
        
        builder.HasKey(s => s.IdSale);

        builder.Property(s => s.CreatedAt).IsRequired();

        builder.HasOne(s => s.IdSubscriptionNavigation)
            .WithMany(d => d.IdSaleNavigation)
            .HasForeignKey(s => s.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.IdClientNavigation)
            .WithMany(c => c.IdSaleNavigation)
            .HasForeignKey(s => s.IdClient)
            .OnDelete(DeleteBehavior.Cascade);
    }
}