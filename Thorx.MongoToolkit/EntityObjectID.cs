using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.IdGenerators;
namespace Thorx.MongoToolkit
{
    public class EntityGuidID<T> : IEntity<string>
    {
        [BsonElement("_id")]
        public string Id { get; set; }

        public void Create()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public void Update(string UpdateId)
        {
            this.Id = UpdateId;
        }
    }
    public class Entity<T,TIdentity> : IEntity<TIdentity>
    {
        [BsonElement("_id")]
        public TIdentity Id { get; set; }

        public virtual void Create()
        {
            
        }
        public virtual void Update(TIdentity UpdateId)
        {
            
        }

        public override bool Equals(object obj)
        {
            var entity = obj as Entity<T, TIdentity>;
            return entity != null &&
                   EqualityComparer<TIdentity>.Default.Equals(Id, entity.Id);
        }

       

        public static bool operator ==(Entity<T, TIdentity> entity1, Entity<T, TIdentity> entity2)
        {
            return EqualityComparer<Entity<T, TIdentity>>.Default.Equals(entity1, entity2);
        }

        public static bool operator !=(Entity<T, TIdentity> entity1, Entity<T, TIdentity> entity2)
        {
            return !(entity1 == entity2);
        }
    }
}
