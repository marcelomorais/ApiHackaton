using System.Collections.Generic;

namespace ApiHackaton.Entities
{
    public class AuthorizedModel
    {
        public string CustomerId { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
