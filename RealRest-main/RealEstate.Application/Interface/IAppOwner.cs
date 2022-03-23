using System;
using RealEstate.Application.Interface.Generic;
using RealEstate.Entities.Entities;

namespace RealEstate.Application.Interface
{
	public interface IAppOwner : IApplicationGeneric<Owner>
	{
		Owner GetEntityByIdIncludes(int Id);
	}
}

