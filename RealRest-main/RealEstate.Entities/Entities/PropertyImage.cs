using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Entities.Entities
{
    public partial class PropertyImage
    {
        public int Idpropertyimage { get; set; }
        public int? Idproperty { get; set; }
        public string Filename { get; set; }
        public bool? Enabled { get; set; }

        public virtual Property IdpropertyNavigation { get; set; }
    }
}
