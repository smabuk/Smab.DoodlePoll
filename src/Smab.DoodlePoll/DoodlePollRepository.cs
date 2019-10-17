using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Smab.DoodlePoll.Models;

namespace Smab.DoodlePoll
{
	public class DoodlePollRepository : IDoodlePollRepository
	{
		public async Task<Poll> GetByIdAsync(string id)
		{
			if (id.Contains('/'))
			{
				// Probably this format: http://doodle.com/poll/{id}
				id = id.Split('/').Last().Trim();
			}

			using HttpClient client = new HttpClient();
			string rawJson = await client.GetStringAsync($"https://doodle.com/api/v2.0/polls/{id}");

			return JsonSerializer.Deserialize<Poll>(rawJson);
		}
	}
}
