using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Models
{
    public class Experiance
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public int Id { get; set; }
        [BsonElement("Company_name")]
        [BsonRequired]
        public string CompanyName { get; set; }
        [BsonElement("Worked_Designation")]
        [BsonRequired]
        public string Designation { get; set; }
        [BsonElement("Worked_for_Duration")]
        [BsonRequired]
        public string Duration { get; set; }
        [BsonElement("Started_From")]
        [BsonDateTimeOptions(Kind =DateTimeKind.Local)]
        [BsonRequired]
        public DateTime StartedFrom { get; set; }
        [BsonElement("Worked_Till")]
        [BsonDateTimeOptions(Kind =DateTimeKind.Local)]
        [BsonRequired]
        public DateTime WorkedTill { get; set; }
    }
}
