using System;

namespace ApiHackaton.Entities
{
    public class Device
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string Type { get; set; }
        public object CustomerId { get; set; }
        public object OfferId { get; set; }
    }

}
