using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thorx.MongoToolkit
{
    public  class ToolkitResponsitory<T> where T: class,IEntity<string>
    {
        public ToolkitResponsitory()
        {
            Repository = new MongoToolkitRepository<T, string>();
        }
        public IEntity<ObjectId> GetEntity { get; set; }
        public  IMongoToolkitRepository<T, string> Repository { get; set; }

    }
}
