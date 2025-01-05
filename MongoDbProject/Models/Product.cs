using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbProject.Models
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
        public string? ProductId { get; set; }

		public string? ProductName { get; set; }

        public int Unit { get; set; }

        public decimal Price { get; set; }

		public string? Category { get; set; }



		
    }
}
