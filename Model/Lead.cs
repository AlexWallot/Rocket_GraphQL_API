using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class Lead
    {
        public long Id { get; set; }
        public string FullNameContact { get; set; }
        public string CompagnyName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NameProject { get; set; }
        public string DescriptionProject { get; set; }
        public string Department { get; set; }
        public string Message { get; set; }
        public byte[] File { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
