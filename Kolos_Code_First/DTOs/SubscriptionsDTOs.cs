using System.Data.SqlTypes;

namespace Kolos_Code_First.Models
{
    public class ClientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<SubscriptionDto> Subscriptions { get; set; }
    }

    public class SubscriptionDto
    {
        public int IdSubscription { get; set; }
        public string Name { get; set; }
        public SqlMoney TotalPaidAmount { get; set; }
    }
}