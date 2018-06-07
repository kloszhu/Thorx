using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Thorx.MongoToolkit
{
    public class MongoToolkitRepository<TEntity, TIdentifier> : IMongoToolkitRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        private readonly IMongoDatabase database;

        public MongoToolkitRepository()
        {
            this.database = new MongoClient(ConfigurationManager.AppSettings["MongoDatabaseConnstring"]).GetDatabase(ConfigurationManager.AppSettings["MongoDatabase"]);
        }

        public TEntity Get(TIdentifier id)
        {
            return this.database.GetCollection<TEntity>(typeof(TEntity).Name).Find(x => x.Id.Equals(id)).FirstOrDefaultAsync().Result;
        }

        public TEntity Find(ISpecification<TEntity> specification)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            return collection.Find(specification.Predicate).FirstOrDefaultAsync().Result;
        }
        public TEntity Find(Expression<Func<TEntity, bool>> expression)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            return collection.Find(expression).FirstOrDefaultAsync().Result;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return this.database.GetCollection<TEntity>(typeof(TEntity).Name).Find(new BsonDocument()).ToListAsync().Result;
        }

        public IEnumerable<TEntity> FindAll(ISpecification<TEntity> specification)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            var listAsync = collection.Find(specification.Predicate).ToListAsync();

            return listAsync.Result;
        }
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity,bool>> expression)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            var listAsync = collection.Find(expression).ToListAsync();

            return listAsync.Result;
        }

        public TEntity Save(TEntity entity)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {

                IsUpsert = true,
            });

            return entity;
        }
        public TEntity Update(TEntity entity) {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);
            collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {

                IsUpsert = true,
            });

            return entity;
        }
        public TEntity Update(TEntity entity,TIdentifier identifier)
        {
            entity.Update(identifier);
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);
            collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {

                IsUpsert = true,
            });

            return entity;
        }

        public TEntity Insert(TEntity entity) {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);
            entity.Create();
            collection.InsertOne( entity, new InsertOneOptions
            {
                BypassDocumentValidation= false
            });

            return entity;
        }
        public IEnumerable<TEntity> Insert(IEnumerable<TEntity> entity)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.InsertManyAsync(entity, new InsertManyOptions
            {
                IsOrdered=true, BypassDocumentValidation=false
                
            });

            return entity;
        }

        public void Delete(TIdentifier id)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.DeleteOneAsync(x => x.Id.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            var collection = this.database.GetCollection<TEntity>(typeof(TEntity).Name);

            collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
        }
    }
}

