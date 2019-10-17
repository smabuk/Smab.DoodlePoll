using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;

namespace Smab.DoodlePoll.Models
{
	[DebuggerDisplay("Name: {Name,nq}")]
	public class Participant
	{
		[JsonPropertyName("id")]
		public int Id { get; set; }

		[JsonPropertyName("name")]
		public string Name { get; set; } = "";

		/// <summary>
		/// 0 or 1 representing NO or YES, null representing "?" an existing vote with a changed poll
		/// </summary>
		/// <returns></returns>
		[JsonPropertyName("preferences")]
		public List<int?> Preferences { get; set; } = new List<int?>();

		[JsonPropertyName("smallAvatarUrl")]
		public string SmallAvatarUrl { get; set; } = "";

		[JsonPropertyName("largeAvatarUrl")]
		public string LargeAvatarUrl { get; set; } = "";

		[JsonPropertyName("userId")]
		public string UserId { get; set; } = "";

		// Derived information
		public VoteType Vote => Preferences.LastOrDefault().HasValue ? (VoteType)Preferences.LastOrDefault() : VoteType.Maybe;
	}
}
