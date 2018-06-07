using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
namespace Thorx.MongoToolkit
{
    public interface IMongoToolkitRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        void Delete(TEntity entity);
        void Delete(TIdentifier id);
        TEntity Find(ISpecification<TEntity> specification);
        TEntity Find(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> FindAll(ISpecification<TEntity> specification);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> expression);
        TEntity Get(TIdentifier id);
        IEnumerable<TEntity> GetAll();
        TEntity Save(TEntity entity);
        TEntity Insert(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Update(TEntity entity, TIdentifier identifier);

    }
}