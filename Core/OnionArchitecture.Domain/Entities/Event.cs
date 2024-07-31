using OnionArchitecture.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        
        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }
        public string Title { get; set; }

        public DateTimeOffset Date { get; set; }

        public Location Location { get; set; }
    }
}
