using Kolos_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos_Code_First.EfConfigurations;

public class PaymentEfConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");
        
        builder.HasKey(p => p.IdPayment);

        builder.Property(p => p.Date).IsRequired();

        builder.HasOne(p => p.IdSubscriptionNavigation)
            .WithMany(d => d.IdPaymentNavigation)
            .HasForeignKey(p => p.IdSubscription)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(p => p.IdClientNavigation)
            .WithMany(c => c.IdPaymentNavigation)
            .HasForeignKey(p => p.IdClient)
            .OnDelete(DeleteBehavior.Cascade);
    }
}