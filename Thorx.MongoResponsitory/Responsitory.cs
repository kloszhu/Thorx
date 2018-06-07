using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Thorx.MongoToolkit;

namespace Thorx.MongoResponsitory
{
    public class Responsitory<T> : IResponsitory<T> where T : BaseGuidModel
    {
        private IMongoToolkitRepository<T, Guid?> Dal{get;set;}
        public Responsitory()
        {
            Dal = new MongoToolkitRepository<T, Guid?>();
        }

        public void Delete(T entity)
        {
            Dal.Delete(entity);
        }

        public void Delete(Guid? id)
        {
            Dal.Delete(id);
        }

        public T Find(ISpecification<T> specification)
        {
            return Dal.Find(specification);
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return Dal.Find(expression);
        }

        public IEnumerable<T> FindAll(ISpecification<T> specification)
        {
            return Dal.FindAll(specification);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression)
        {
            return Dal.FindAll(expression);
        }

        public T Get(Guid? id)
        {
            return Dal.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Dal.GetAll();
        }

        public T Insert(T entity)
        {
            return Dal.Insert(entity);
        }

        public T Save(T entity)
        {
            return Dal.Save(entity);
        }

        public T Update(T entity)
        {
            return Dal.Update(entity);
        }

        public T Update(T entity, Guid? identifier)
        {
            return Dal.Update(entity, identifier);
        }
    }
}
