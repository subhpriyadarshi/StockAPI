using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

public class ListedStocks
{

        [JsonIgnore]
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string SYMBOL { get; set; }
        public string NAMEOFCOMPANY { get; set; }
        public string SERIES { get; set; }
}