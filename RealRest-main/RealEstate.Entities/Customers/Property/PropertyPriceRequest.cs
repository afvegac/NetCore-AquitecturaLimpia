using System;
namespace RealEstate.Entities.Customers.Property
{
	public class PropertyPriceRequest
	{
		public PropertyPriceRequest()
        {

        }
		public int idProperty { get; set; }
		public decimal price { get; set; }
	}
}

