using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Quote
    {
        public int Id { get; set; }
        public string TypeBuilding { get; set; }
        public int? NumApartment { get; set; }
        public int? NumFloor { get; set; }
        public int? NumElevator { get; set; }
        public int? NumOccupant { get; set; }
        public string CompagnyName { get; set; }
        public string Email { get; set; }
        public string TypeService { get; set; }
        public decimal? TotalElevatorPrice { get; set; }
        public decimal? Total { get; set; }
        public decimal? InstallationFees { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
