using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class DimCustomer
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompagnyName { get; set; }
        public string FullNameContact { get; set; }
        public string Email { get; set; }
        public int NbElevator { get; set; }
        public string City { get; set; }
    }
}
