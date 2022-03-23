using System;
using System.Collections.Generic;

#nullable disable

namespace RealEstate.Entities.Entities
{
    public partial class Property
    {
        public Property()
        {
            PropertyImages = new HashSet<PropertyImage>();
            PropertyTraces = new HashSet<PropertyTrace>();
        }

        public int Idproperty { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public int? Codeinternal { get; set; }
        public int? Year { get; set; }
        public int? Idowner { get; set; }

        public virtual Owner IdownerNavigation { get; set; }
        public virtual ICollection<PropertyImage> PropertyImages { get; set; }
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; }
    }
}
