using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Building
    {
        public Building()
        {
            Batteries = new HashSet<Battery>();
            BuildingDetails = new HashSet<BuildingDetail>();
        }

        public long Id { get; set; }
        public long? CustomerId { get; set; }
        public long? AddressId { get; set; }
        public string FullNameAdministrator { get; set; }
        public string EmailAdministrator { get; set; }
        public string PhoneNumberAdministrator { get; set; }
        public string FullNameTechnicalContact { get; set; }
        public string EmailTechnicalContact { get; set; }
        public string PhoneTechnicalContact { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Address Address { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
        public virtual ICollection<BuildingDetail> BuildingDetails { get; set; }
    }
}
