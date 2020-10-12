using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Domain.Entities
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("UserId")]
        [Required]
        public string UserId { get; set; }

        [BsonElement("ImagePath")]
        [Required]
        public string ImagePath { get; set; }

        [BsonElement("Comment")]
        [Required]
        public string Comment { get; set; }
    }
}
