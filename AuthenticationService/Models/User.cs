using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace AuthenticationService.Models
{
	public class User
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

        //public bool IsActive { get; set; }

        //public string CreatedDate { get; set; }
        /*
        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<string> movieIds { get; set; } = null!;
        */

    }
}

