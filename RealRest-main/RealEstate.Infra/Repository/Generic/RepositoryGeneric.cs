using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RealEstate.Domain.Interface.Generic;
using RealEstate.Infra.Config;

namespace RealEstate.Infra.Repository.Generic
{
    public class RepositoryGeneric<T> : InterfaceGeneric<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<RealEstateContext> _OptionsBuilder;
        public RepositoryGeneric()
        {
            _OptionsBuilder = new DbContextOptions<RealEstateContext>();

        }
        ~RepositoryGeneric()
        {
            Dispose(false);
        }
        public void Add(T Entitie)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                var res = context.Add(Entitie);
                context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {

                context.Remove(GetEntityById(id));
                context.SaveChanges();
            }
        }

        public List<T> List()
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                return context.Set<T>().ToList();
            }
        }

        public void Update(T Entitie)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                context.Update(Entitie);
                context.SaveChanges();
            }
        }
        public T GetEntityById(int Id)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                return context.Set<T>().Find(Id);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool status)
        {
            if (!status)
            {
                return;
            }
        }

        public List<T> List(Expression<Func<T, bool>> criteria)
        {
            using (var context = new RealEstateContext(_OptionsBuilder))
            {
                return context.Set<T>().Where(criteria).ToList();
            }
            //throw new NotImplementedException();
        }
    }
}

