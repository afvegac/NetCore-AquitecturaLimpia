using System;
using RealEstate.Domain.Interface.Generic;
using RealEstate.Entities.Entities;

namespace RealEstate.Domain.Interface
{
	public interface InterfaceOwner : InterfaceGeneric<Owner>
	{
		Owner GetEntityByIdIncludes(int Id);
	}
}

