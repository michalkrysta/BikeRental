using System;
using System.Collections.Generic;

namespace BikeRental.Core.Domain
{
    public class Customer
    {
        private ISet<Bicycle> _bicycles = new HashSet<Bicycle>();


        protected Customer(DateTime updatedAt)
        {
            UpdatedAt = updatedAt;
        }

        public Customer(User user)
        {
            UserId = user.Id;
            Name = user.Username;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public DateTime UpdatedAt { get; private set; }

        public IEnumerable<Bicycle> Bicycles
        {
            get => _bicycles;
            set => _bicycles = new HashSet<Bicycle>(value);
        }
    }
}