using Smab.DoodlePoll.Helpers;
using System;
using System.Text.Json.Serialization;

namespace Smab.DoodlePoll.Models
{
	public class Comment
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("author")]
		public string Author { get; set; } = "";

		[JsonPropertyName("timestamp")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime Timestamp { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; } = "";

		[JsonPropertyName("userId")]
		public string UserId { get; set; } = "";
	}
}