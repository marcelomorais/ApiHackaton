using System;
using System.Collections.Generic;

namespace ApiHackaton.Entities
{
    public class AuthorizedModel
    {
        public int CustomerId { get; set; }
        public string Label { get; set; }
        public Guid CartId { get; set; }
        public List<DeviceOffer> DeviceOffers { get; set; }
    }
}
