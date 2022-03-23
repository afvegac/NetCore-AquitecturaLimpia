using System;
using System.Linq.Expressions;
using RealEstate.Application.Interface;
using RealEstate.Domain.Interface;
using RealEstate.Entities.Entities;

namespace RealEstate.Application.App
{
	public class AppPropertyImage : IAppPropertyImage
	{
        InterfacePropertyImage _InterfacePropertyImage;
        public AppPropertyImage(InterfacePropertyImage interfacePropertyImage)
		{
            _InterfacePropertyImage = interfacePropertyImage;
		}

        public void Add(PropertyImage Entitie)
        {
            _InterfacePropertyImage.Add(Entitie);
        }

        public void Delete(int id)
        {
            _InterfacePropertyImage.Delete(id);
        }

        public PropertyImage GetEntityById(int Id)
        {
            return _InterfacePropertyImage.GetEntityById(Id);
        }

        public List<PropertyImage> List()
        {
            return _InterfacePropertyImage.List();
        }

        public List<PropertyImage> List(Expression<Func<PropertyImage, bool>> criteria)
        {
            return _InterfacePropertyImage.List(criteria);
        }

        public void Update(PropertyImage Entitie)
        {
            _InterfacePropertyImage.Update(Entitie);
        }
    }
}

