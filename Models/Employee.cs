using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoreMongoDBCrud.Models
{
    public class Employee
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

        public string Name { get; set; } = "";

        public string CardNumber { get; set; } = "";

        public decimal Salary { get; set; } = 0;
    }
}



