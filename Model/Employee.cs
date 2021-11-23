using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Employee
    {
        public Employee()
        {
            Batteries = new HashSet<Battery>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Battery> Batteries { get; set; }
    }
}
