using System;
using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Interface;
using RealEstate.Entities.Entities;
using RealEstate.Infra.Config;
using RealEstate.Infra.Repository.Generic;

namespace RealEstate.Infra.Repository
{
	public class RepositoryProperty : RepositoryGeneric<Property>, InterfaceProperty
	{
        private readonly DbContextOptions<RealEstateContext> _OptionsBuilder;
        public RepositoryProperty()
        {
            _OptionsBuilder = new DbContextOptions<RealEstateContext>();

        }

        public List<Property> GetAll()
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                return context.Properties.Include(x => x.IdownerNavigation).ToList();
            }
        }

        public Property GetEntityByIdIncludes(int Id)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                return context.Properties.Include(x => x.IdownerNavigation).FirstOrDefault(x => x.Idproperty == Id);
            }
        }
    }
}

