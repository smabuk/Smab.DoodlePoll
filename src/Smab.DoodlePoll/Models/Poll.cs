using Smab.DoodlePoll.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;

namespace Smab.DoodlePoll.Models
{
	[DebuggerDisplay("Title: {Title,nq}")]
	public class Poll
	{
		[JsonPropertyName("id")]
		public string Id { get; set; } = "";

		[JsonPropertyName("latestChange")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime LatestChange { get; set; }

		[JsonPropertyName("initiated")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime Initiated { get; set; }

		[JsonPropertyName("closed")]
		[JsonConverter(typeof(JsonUnixDateConverter))]
		public DateTime Closed { get; set; }

		[JsonPropertyName("participantsCount")]
		public int ParticipantsCount { get; set; }

		[JsonPropertyName("inviteesCount")]
		public int InviteesCount { get; set; }

		[JsonPropertyName("type")]
		public string Type { get; set; } = "";

		[JsonPropertyName("columnConstraint")]
		public int ColumnConstraint { get; set; }

		[JsonPropertyName("preferencesType")]
		public string PreferencesType { get; set; } = "";

		[JsonPropertyName("state")]
		public string State { get; set; } = "";

		[JsonPropertyName("locale")]
		public string Locale { get; set; } = "";

		[JsonPropertyName("title")]
		public string Title { get; set; } = "";

		[JsonPropertyName("location")]
		public Location? Locations { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; } = "";

		[JsonPropertyName("initiator")]
		public Initiator Initiators { get; set; } = new Initiator();

		[JsonPropertyName("options")]
		public List<Option> Options { get; set; } = new List<Option>();

		[JsonPropertyName("optionsHash")]
		public string? OptionsHash { get; set; }

		[JsonPropertyName("comments")]
		public List<Comment> Comments { get; set; } = new List<Comment>();

		[JsonPropertyName("participants")]
		public List<Participant> Participants { get; set; } = new List<Participant>();

		[JsonPropertyName("device")]
		public string Device { get; set; } = "";

		[JsonPropertyName("levels")]
		public string Levels { get; set; } = "";


		// Extra derived properties

		public bool HasComments => Comments?.Any() ?? false;
		public bool HasParticipants => Participants?.Any() ?? false;
		public bool HasOptions => Options?.Any() ?? false;


		public int YesCount =>
			Participants.Where(p => p.Vote == VoteType.Yes).Count();

		public int NoCount =>
			Participants.Where(p => p.Vote == VoteType.No).Count();

		public int MaybeCount =>
			Participants.Where(p => p.Vote == VoteType.Maybe).Count();

	}
}