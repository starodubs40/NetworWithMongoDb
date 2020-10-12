using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Network.Domain.Entities
{
    public class Profile
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }


        [BsonElement("UserName")]
        [Required]
        public string UserName { get; set; }

        [BsonElement("TitleImagePath")]
        [Required]
        public string TitleImagePath { get; set; }

        public string[] Posts { get; set; }
    }
}
