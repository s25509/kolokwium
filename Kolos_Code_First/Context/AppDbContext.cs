using Kolos_Code_First.EfConfigurations;
using Kolos_Code_First.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos_Code_First.Context;

public class AppDbContext : DbContext
{
    public AppDbContext() {}
    
    public AppDbContext(DbContextOptions options) : base(options) { }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEfConfiguration());
        modelBuilder.ApplyConfiguration(new SubscriptionEfConfiguration());
        modelBuilder.ApplyConfiguration(new SaleEfConfiguration());
        modelBuilder.ApplyConfiguration(new PaymentEfConfiguration());
        modelBuilder.ApplyConfiguration(new DiscountEfConfiguration());
    }
}