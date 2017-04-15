using Microsoft.Extensions.Logging;
using MongoDB.Bson;

namespace Meet.Extensions.Logging.Log2Mongo
{
    public class MongoLoggerModel
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LogLevel { get; set; }

        public EventId EventId { get; set; }

        public dynamic State { get; set; }

        public string Content { get; set; }
    }
}
