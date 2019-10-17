using System.Text.Json.Serialization;

namespace Smab.DoodlePoll.Models
{
	public class Location
	{
		[JsonPropertyName("name")]
		public string Name { get; set; } = "";

		[JsonPropertyName("address")]
		public string Address { get; set; } = "";

		[JsonPropertyName("countryCode")]
		public string CountryCode { get; set; } = "";

		[JsonPropertyName("locationId")]
		public string LocationId { get; set; } = "";
	}
}
