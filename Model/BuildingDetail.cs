using System;
using System.Collections.Generic;

#nullable disable

namespace DotNetGQL.Model
{
    public partial class BuildingDetail
    {
        public long Id { get; set; }
        public long BuildingId { get; set; }
        public string InformationKey { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Building Building { get; set; }
    }
}
