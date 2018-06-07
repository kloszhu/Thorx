using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thorx.MongoToolkit;

namespace MongoTest.model
{
    public class Piano: BaseModel
    {
        public string Name { get;  set; }
        public string Player { get;  set; }     
    }
}
