using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Column
    {
        public Column()
        {
            Elevators = new HashSet<Elevator>();
        }

        public long Id { get; set; }
        public long BatteryId { get; set; }
        public string Types { get; set; }
        public string NumberFloorServed { get; set; }
        public string Status { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Battery Battery { get; set; }
        public virtual ICollection<Elevator> Elevators { get; set; }

        public Boolean getElevatorList(List<Elevator> filteredElevators) 
        {
            var currentElevators = new List<Elevator>();
            foreach(Elevator elevator in filteredElevators) 
            {
                if ( elevator.ColumnId == this.Id) 
                {
                    currentElevators.Add(elevator);
                }
            }

            if (currentElevators.Count > 0) 
            {
                return true;
            }
            return false;
        }
    }
}
