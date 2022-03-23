using System;
using System.Linq.Expressions;
using RealEstate.Application.Interface;
using RealEstate.Domain.Interface;
using RealEstate.Entities.Entities;
using RealEstate.Infra.Repository;

namespace RealEstate.Application.App
{
	public class AppProperty : IAppProperty
	{
        InterfaceProperty _InterfaceProperty;

        public AppProperty(InterfaceProperty InterfaceProperty)
		{
            _InterfaceProperty = InterfaceProperty;
        }

        public void Add(Property Entitie)
        {
            _InterfaceProperty.Add(Entitie);
        }

        public void Delete(int id)
        {
            _InterfaceProperty.Delete(id);
        }

        public List<Property> GetAll()
        {
            return _InterfaceProperty.GetAll();
        }

        public Property GetEntityById(int Id)
        {
            return _InterfaceProperty.GetEntityById(Id);
        }

        public Property GetEntityByIdIncludes(int Id)
        {
            return _InterfaceProperty.GetEntityByIdIncludes(Id);
        }

        public List<Property> List()
        {
            return _InterfaceProperty.List();
        }

        public List<Property> List(Expression<Func<Property, bool>> criteria)
        {
            return _InterfaceProperty.List(criteria);
        }

        public void Update(Property Entitie)
        {
            _InterfaceProperty.Update(Entitie);
        }
    }
}

