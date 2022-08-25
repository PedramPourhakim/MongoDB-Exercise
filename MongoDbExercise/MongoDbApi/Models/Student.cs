using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace MongoDbApi.Models
{
    [BsonIgnoreExtraElements] //If Mongo Db Has Extra Fields,They Will Ignore
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] //this attribute convert data type from mongo db datatype and vice versa
        public string Id { get; set; } = string.Empty;
        [BsonElement("name")]
        public string Name { get; set; } = string.Empty;
        [BsonElement("graduated")] //its mapping boolean is graduated property to graduated field in mongo documnet
        public bool IsGraduated { get; set; }
        [BsonElement("courses")]
        public string[]? Courses { get; set; }
        [BsonElement("gender")]
        public string Gender { get; set; } = string.Empty;
        [BsonElement("age")]
        public int Age { get; set; }
    }
}
