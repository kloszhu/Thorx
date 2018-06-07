using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thorx.MongoToolkit
{
    public class Responsitory<T, TIdentifier> where T : class, IEntity<TIdentifier>
    {
        public Responsitory()
        {
            Repository = new MongoRepository<T, TIdentifier>();
        }
        public IEntity<TIdentifier> GetEntityID { get; set; }
        public IMongoRepository<T, TIdentifier> Repository { get; set; }

    }
}
