using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thorx.MongoToolkit;

namespace MongoTest.model
{
    public  class City: EntityGuidID<string>
    {
        public string num { get; set; }
        public string name { get; set; }
        public Door WhitchDoor { get; set; } = new Door();
    }
}
