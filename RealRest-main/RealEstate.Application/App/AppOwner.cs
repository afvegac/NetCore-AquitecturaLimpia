using System;
using System.Linq.Expressions;
using RealEstate.Application.Interface;
using RealEstate.Domain.Interface;
using RealEstate.Entities.Entities;
using RealEstate.Infra.Repository;

namespace RealEstate.Application.App
{
    public class AppOwner : IAppOwner
	{
        InterfaceOwner _InterfaceOwner;

        public AppOwner(InterfaceOwner InterfaceOwner)
		{
            _InterfaceOwner = InterfaceOwner;
        }

        public void Add(Owner Entitie)
        {
            _InterfaceOwner.Add(Entitie);
        }

        public void Delete(int id)
        {
            _InterfaceOwner.Delete(id);
        }

        public Owner GetEntityById(int Id)
        {
            return _InterfaceOwner.GetEntityById(Id) ;
        }

        public Owner GetEntityByIdIncludes(int Id)
        {
            return _InterfaceOwner.GetEntityByIdIncludes(Id);
        }

        public List<Owner> List()
        {
            return _InterfaceOwner.List();
        }

        public List<Owner> List(Expression<Func<Owner, bool>> criteria)
        {
            return _InterfaceOwner.List(criteria);
        }

        public void Update(Owner Entitie)
        {
            _InterfaceOwner.Update(Entitie);
        }
    }
}

