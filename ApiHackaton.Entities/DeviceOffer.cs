using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiHackaton.Entities
{
    public class DeviceOffer
    {
        public string TokenName { get; set; }
        public string DeviceId { get; set; }
        public Offer Offer { get; set; }
    }
}
