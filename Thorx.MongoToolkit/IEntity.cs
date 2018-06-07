using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Thorx.MongoToolkit
{
    public interface IEntity<TIdentifier>
    {
       
        TIdentifier Id { get; set; }
        void Create();
        void Update(TIdentifier UpdateId);
    }
}