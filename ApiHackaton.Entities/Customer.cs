using System;

namespace ApiHackaton.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int CreditCardId { get; set; }

        public int AddressId { get; set; }
    }
}