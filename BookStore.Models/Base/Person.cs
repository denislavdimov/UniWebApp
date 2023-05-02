using MongoDB.Bson.Serialization.Attributes;

namespace BookStore.Models.Models
{
	public class Person
	{
        //[BsonId]
        //[BsonElement("_id")]

        public int Id { get; set; }
		public string Name { get; set; }
	}
}

