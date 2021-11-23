using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Customer
    {
        public Customer()
        {
            Buildings = new HashSet<Building>();
        }

        public long Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreation { get; set; }
        public string CompagnyName { get; set; }
        public long AddressId { get; set; }
        public string FullName { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string FullNameTechnicalAuthority { get; set; }
        public string TechnicalAuthorityPhone { get; set; }
        public string TechnicalAuthorityEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
    }
}
