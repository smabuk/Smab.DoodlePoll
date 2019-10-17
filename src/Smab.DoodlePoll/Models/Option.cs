using Smab.DoodlePoll.Helpers;
using System;
using System.Text.Json.Serialization;

namespace Smab.DoodlePoll.Models
{
	public class Option
	{
		[JsonPropertyName("start")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime Start { get; set; }

		[JsonPropertyName("end")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime End { get; set; }

		[JsonConverter(typeof(JsonUnixDateConverter))]
		[JsonPropertyName("startDateTime")]
		public DateTime StartDateTime { get; set; }

		[JsonConverter(typeof(JsonUnixDateConverter))]
		[JsonPropertyName("endDateTime")]
		public DateTime EndDateTime { get; set; }

		[JsonPropertyName("text")]
		public string Text { get; set; } = "";

		[JsonPropertyName("available")]
		public bool Available { get; set; }

		[JsonPropertyName("final")]
		public bool Final { get; set; }
	}
}
