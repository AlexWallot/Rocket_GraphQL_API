using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Battery
    {
        public Battery()
        {
            Columns = new HashSet<Column>();
        }

        public long Id { get; set; }
        public long BuildingId { get; set; }
        public string Types { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public DateTime DateCommissioning { get; set; }
        public DateTime DateLastInspection { get; set; }
        public string CertificateOperations { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Building Building { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}
