using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string EncryptedPassword { get; set; }
        public string ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordSentAt { get; set; }
        public DateTime? RememberCreatedAt { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
