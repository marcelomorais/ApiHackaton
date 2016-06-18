using System.Collections.Generic;

namespace ApiHackaton.Entities
{
    public class AuthorizedModel
    {
        public int CustomerId { get; set; }
        public string TokenName { get; set; }
        public List<Offer> Offers { get; set; }
    }
}
