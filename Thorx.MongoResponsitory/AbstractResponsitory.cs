using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thorx.MongoResponsitory
{
    public abstract class AbstractResponsitory<T> where T : BaseGuidModel
    {
        public AbstractResponsitory():base() { }
        public static IResponsitory<T> Responsitory { get; set; }=new Responsitory<T>();
    }
}
