namespace Kolos_Code_First.Models;

public class Client
{
    public int IdClient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    
    public virtual ICollection<Sale> IdSaleNavigation { get; set; }
    public virtual ICollection<Payment> IdPaymentNavigation { get; set; }
}