using System;

namespace SportsXs.Domain.Entities
{
    public class Phones : BaseEntity
    {
        public Phones()
        {
        }
        public Phones(string number, Guid clientId)
        {
            Number = number;
            ClientId = clientId;
        }
        public string Number { get; private set; }
        public Guid ClientId { get; set; }
        public void Update(string number)
        {
            Number = number;
        }
    }
}
