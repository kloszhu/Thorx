using System;
using Thorx.MongoToolkit;
namespace Thorx.MongoResponsitory
{
    public interface IResponsitory<T> : IMongoToolkitRepository<T,Guid?> where T : BaseGuidModel
    {
         
    }
}