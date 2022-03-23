using System;
using RealEstate.Domain.Interface.Generic;
using RealEstate.Entities.Entities;

namespace RealEstate.Domain.Interface
{
	public interface InterfaceProperty : InterfaceGeneric<Property>
	{
		Property GetEntityByIdIncludes(int Id);

		List<Property> GetAll();
	}
}

