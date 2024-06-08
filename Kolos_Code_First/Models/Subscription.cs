using System.Data.SqlTypes;

namespace Kolos_Code_First.Models;

public class Subscription
{
    public int IdSubscription { get; set; }
    public string Name { get; set; }
    public int RenewalPeriod { get; set; }
    public DateTime EndTime { get; set; }
    public SqlMoney Price { get; set; }
    
    public virtual ICollection<Discount> IdDiscountNavigation { get; set; }
    public virtual ICollection<Sale> IdSaleNavigation { get; set; }
    public virtual ICollection<Payment> IdPaymentNavigation { get; set; }

}