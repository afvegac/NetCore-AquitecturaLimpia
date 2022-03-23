using System;
namespace RealEstate.Entities.Customers.Property
{
	public class propertyFiltersRequest
	{
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal? Price { get; set; }
        public int? Codeinternal { get; set; }
        public int? Year { get; set; }
        public int? Idowner { get; set; }
    }
}

