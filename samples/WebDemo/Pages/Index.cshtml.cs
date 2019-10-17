using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Smab.DoodlePoll;
using Smab.DoodlePoll.Models;

namespace WebDemo.Pages
{
	public class IndexModel : PageModel
	{
		public IndexModel(
			ILogger<IndexModel> logger,
			IDoodlePollService doodlePollService
			)
		{
			_logger = logger;
			_doodlePollService = doodlePollService;
		}

		public async Task OnGetAsync()
		{
			SessionIds = new string[]
			{
				// Create a Doodle Poll and paste the Url or id into the line below
				"https://doodle.com/poll/abcdefghij123456"
			 };

			foreach (var id in SessionIds.Where(id => !String.IsNullOrEmpty(id)))
			{
				Poll doodlePoll;
				try
				{
					doodlePoll = await _doodlePollService.GetByIdAsync(id);
				}
				catch (Exception ex)
				{
					_logger.LogError("Poll {id} not found.\n{exMessage}", id, ex.Message);
					Message += $"Poll {id} not found. {ex.Message}";
					continue;
				}

				Session sess = new Session
				{
					DoodlePollId = id,
					Description =doodlePoll.Description,
					Name = doodlePoll.Title,
					State = doodlePoll.State?.ToLower(),
					Created = doodlePoll.Initiated,
					UpDated = doodlePoll.LatestChange,
					MaxNoOfAttendees = doodlePoll.ColumnConstraint,
					Start = doodlePoll.Options.First().Start,
					HasComments = doodlePoll.HasComments,
					YesCount = doodlePoll.YesCount,
					NoCount = doodlePoll.NoCount,
					MaybeCount = doodlePoll.MaybeCount
				};

				if (doodlePoll.HasParticipants)
				{
					int i = 1;
					var attendees = from p in doodlePoll.Participants
									select new Attendee
									{
										Name = p.Name,
										Attending = p.Vote,
										Index = i++
									};
					sess.Attendees = attendees.ToList();
				}

				if (doodlePoll.HasComments)
				{
					var comments = from c in doodlePoll.Comments
								   select new Comment
								   {
									   Author = c.Author,
									   Text = c.Text,
									   TimeStamp = c.Timestamp
								   };
					sess.Comments = comments.ToList();
				}

				Sessions.Add(sess);
			}

		}

		public string Message { get; set; } = "";
		public string[]? SessionIds { get; set; }
		public List<Session> Sessions { get; set; } = new List<Session>();

		public class Attendee
		{
			public int Index { get; set; }
			public string Name { get; set; } = "";
			public VoteType Attending { get; set; }
		}

		public class Comment
		{
			public string Author { get; set; } = "";
			public DateTime TimeStamp { get; set; }
			public string Text { get; set; } = "";
		}

		public class Session
		{
			private string _DoodlePollId = "";
			public string DoodlePollId
			{
				get { return _DoodlePollId; }
				set
				{
					if (value.Contains("/"))
					{
						// Probably this format: http://doodle.com/poll/{id}
						value = value.Split("/").Last().Trim();
					}
					_DoodlePollId = value;
				}
			}
			public string? Name { get; set; }
			public string? Description { get; set; }
			public string? State { get; set; }
			public DateTime Start { get; set; }
			public DateTime Created { get; set; }
			public DateTime UpDated { get; set; }
			public int MaxNoOfAttendees { get; set; }
			public List<Attendee> Attendees { get; set; } = new List<Attendee>();
			public List<Comment> Comments { get; set; } = new List<Comment>();

			public bool HasComments { get; set; }
			public int YesCount { get; set; }
			public int NoCount { get; set; }
			public int MaybeCount { get; set; }
		}


		private readonly ILogger<IndexModel> _logger;
		private readonly IDoodlePollService _doodlePollService;

	}
}

