using System;
using System.Collections.Generic;
using System.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoApi.Models
{
    public class TodoItem
    {

        [BsonId]
        public MongoDB.Bson.ObjectId _id { get; set; }
        public long UserId { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}