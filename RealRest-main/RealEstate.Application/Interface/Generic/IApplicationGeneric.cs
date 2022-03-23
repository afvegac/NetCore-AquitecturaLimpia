using System;
using System.Linq.Expressions;

namespace RealEstate.Application.Interface.Generic
{
    public interface IApplicationGeneric<T> where T : class
    {
        void Add(T Entitie);
        void Update(T Entitie);
        void Delete(int id);
        List<T> List();
        T GetEntityById(int Id);
        List<T> List(Expression<Func<T, bool>> criteria);

    }
}

