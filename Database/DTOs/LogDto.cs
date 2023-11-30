using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAir_Airlines.Models;

public class LogDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Timestamp")]
    public DateTime Timestamp { get; set; }

    [BsonElement("Level")]
    public string Level { get; set; }

    [BsonElement("MessageTemplate")]
    public string MessageTemplate { get; set; }

    [BsonElement("RenderedMessage")]
    public string RenderedMessage { get; set; }

    [BsonElement("Properties")]
    public LogProperties Properties { get; set; } = new LogProperties();

    [BsonElement("UtcTimestamp")]
    public string UtcTimestamp { get; set; }
}

public class LogProperties
{
    [BsonElement("OperationType")]
    public string OperationType { get; set; }

    [BsonElement("Username")]
    public string Username { get; set; }

    // Other properties as needed
    // For example:
    [BsonElement("ActionId")]
    public string ActionId { get; set; }

    [BsonElement("ActionName")]
    public string ActionName { get; set; }

    [BsonElement("RequestId")]
    public string RequestId { get; set; }

    [BsonElement("RequestPath")]
    public string RequestPath { get; set; }

    [BsonElement("ConnectionId")]
    public string ConnectionId { get; set; }

    [BsonElement("Application")]
    public string Application { get; set; }
}
