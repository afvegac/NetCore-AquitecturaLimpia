using System;
using RealEstate.Application.Interface.Generic;
using RealEstate.Entities.Entities;

namespace RealEstate.Application.Interface
{
	public interface IAppProperty : IApplicationGeneric<Property>
	{
		Property GetEntityByIdIncludes(int Id);

		List<Property> GetAll();
	}
}

