

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace simple_pag_Domain.Models
{
    public class LogInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Classe { get; set; }
        public string? Informacao { get; set; }
    }
}
