using System;

namespace ApiHackaton.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime AuthorizedOn { get; set; }
        public object CapturedOn { get; set; }
        public object VoidedOn { get; set; }
        public string PaymentId { get; set; }
        public string DeviceId { get; set; }
        public string MerchantId { get; set; }
        public int CreditCardId { get; set; }
        public int OfferId { get; set; }
        public int CustomerId { get; set; }
        public int Amount { get; set; }
        public int Status { get; set; }
    }    
}
