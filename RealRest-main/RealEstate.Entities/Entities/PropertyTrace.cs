using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Entities.Entities
{
    public partial class PropertyTrace
    {
        public int Idpropertytrace { get; set; }
        public DateTime? Datesale { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
        public decimal? Tax { get; set; }
        public int? Idproperty { get; set; }

        public virtual Property IdpropertyNavigation { get; set; }
    }
}
