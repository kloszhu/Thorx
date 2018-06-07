using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thorx.MongoToolkit;
namespace MongoTest.model
{
    public class Door: EntityGuidID<string>
    {
 
        [BsonElement("code")]
        public int Code { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
    }
}
