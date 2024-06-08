using Kolos_Code_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolos_Code_First.EfConfigurations;

public class SubscriptionEfConfiguration : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscription");
        
        builder.HasKey(s => s.IdSubscription);
        builder.Property(s => s.IdSubscription).ValueGeneratedOnAdd();

        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.RenewalPeriod).IsRequired();
        builder.Property(s => s.EndTime).IsRequired();
        builder.Property(s => s.Price).IsRequired();
    }
}