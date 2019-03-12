using System;
using System.Collections.Generic;
using BikeRental.Core.Domain;

namespace BikeRental.Infrastructure.DTO
{
    public class CustomerDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Bicycle> Bicycles { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}