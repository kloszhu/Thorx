using System.Linq.Expressions;
using System.Linq;
using MongoDB.Driver;

namespace Thorx.MongoToolkit
{
    public interface ISpecification<TEntity>
    {
        FilterDefinition<TEntity> Predicate { get; set; }
    }
}