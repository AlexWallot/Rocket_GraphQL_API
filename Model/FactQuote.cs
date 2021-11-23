using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class FactQuote
    {
        public long Id { get; set; }
        public long QuoteId { get; set; }
        public DateTime CreationDate { get; set; }
        public string CompagnyName { get; set; }
        public string Email { get; set; }
        public int NbElevator { get; set; }
    }
}
