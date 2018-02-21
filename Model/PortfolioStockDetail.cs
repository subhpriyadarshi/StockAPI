using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace TodoApi.Models
{
    public class PortfolioStockDetail
    {

        [JsonIgnore]
        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public long UserId { get; set; }
        public string StockName { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}