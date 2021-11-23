using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class FactContact
    {
        public long Id { get; set; }
        public long ContactId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompagnyName { get; set; }
        public string Email { get; set; }
        public string NameProject { get; set; }
    }
}
