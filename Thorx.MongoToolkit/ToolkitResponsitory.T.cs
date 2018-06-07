using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thorx.MongoToolkit
{
    public class ToolkitResponsitory<T, TIdentifier> where T : class, IEntity<TIdentifier>
    {
        public ToolkitResponsitory()
        {
            Repository = new MongoToolkitRepository<T, TIdentifier>();
        }
        public IEntity<TIdentifier> GetEntityID { get; set; }
        public IMongoToolkitRepository<T, TIdentifier> Repository { get; set; }

    }
}
