using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class FactIntervention
    {
        public long Id { get; set; }
        public long EmployeeId { get; set; }
        public long BuildingId { get; set; }
        public long? BatteryId { get; set; }
        public long? ColumnId { get; set; }
        public long? ElevatorId { get; set; }
        public DateTime DateAndTimeInterventionStart { get; set; }
        public DateTime DateAndTimeInterventionEnd { get; set; }
        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }
    }
}
