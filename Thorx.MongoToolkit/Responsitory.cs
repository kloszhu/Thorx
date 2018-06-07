using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thorx.MongoToolkit
{
    public  class Responsitory<T> where T: class,IEntity<string>
    {
        public Responsitory()
        {
            Repository = new MongoRepository<T, string>();
        }
        public IEntity<ObjectId> GetEntity { get; set; }
        public  IMongoRepository<T, string> Repository { get; set; }

    }
}
