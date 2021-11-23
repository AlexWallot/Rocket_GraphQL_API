using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Address
    {
        public Address()
        {
            Buildings = new HashSet<Building>();
            Customers = new HashSet<Customer>();
        }

        public long Id { get; set; }
        public string TypeAddress { get; set; }
        public string Status { get; set; }
        public string Entity { get; set; }
        public string NumberAndStreet { get; set; }
        public string SuiteOrApartment { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public float Lat { get; set; }
        public float Long { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
