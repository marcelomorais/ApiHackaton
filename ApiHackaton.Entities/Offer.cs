using System;

namespace ApiHackaton.Entities
{

    public class Offer
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public string MerchantSku { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string MerchantId { get; set; }
    }

}
