using System;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Interface;
using RealEstate.Entities.Entities;
using RealEstate.Infra.Config;
using RealEstate.Infra.Repository.Generic;

namespace RealEstate.Infra.Repository
{
    public class RepositoryOwner : RepositoryGeneric<Owner>, InterfaceOwner
	{
        private readonly DbContextOptions<RealEstateContext> _OptionsBuilder;
        public RepositoryOwner()
        {
            _OptionsBuilder = new DbContextOptions<RealEstateContext>();

        }
        public Owner GetEntityByIdIncludes(int Id)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                return context.Owners.Include(x=>x.Properties).FirstOrDefault(x=>x.Idowner==Id);
            }
        }
    }
}

