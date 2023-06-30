using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebApiDemo.Abstractions.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        List<T> GetAll();
        List<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(List<T> entities);

        //IEnumerable<T> FindWithSpecificationPattern(ISpecification<T> specification = null);
    }
}
