

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace simple_pag_Domain.Shared.Models
{
    public class LogInformation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string? Classe { get; set; }
        public string? Informacao { get; set; }
        public string? registro { get; set; }=DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    }
}
