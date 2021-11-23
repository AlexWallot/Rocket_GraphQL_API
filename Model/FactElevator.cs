using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class FactElevator
    {
        public long Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateCommissioning { get; set; }
        public long BuildingId { get; set; }
        public long CustomerId { get; set; }
        public string City { get; set; }
    }
}
