namespace Kolos_Code_First.Models;

public class Payment
{
    public int IdPayment { get; set; }
    public int IdClient { get; set; }
    public int IdSubscription { get; set; }
    public DateTime Date { get; set; }

    public virtual Subscription IdSubscriptionNavigation { get; set; }
    public virtual Client IdClientNavigation { get; set; }
}