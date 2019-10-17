using System.Text.Json.Serialization;

namespace Smab.DoodlePoll.Models
{
	public class Initiator
	{
		[JsonPropertyName("Name")]
		public string Name { get; set; } = "";

		[JsonPropertyName("notify")]
		public bool Notify { get; set; }

		[JsonPropertyName("timeZone")]
		public string TimeZone { get; set; } = "";

		[JsonPropertyName("userId")]
		public string UserId { get; set; } = "";
	}
}
