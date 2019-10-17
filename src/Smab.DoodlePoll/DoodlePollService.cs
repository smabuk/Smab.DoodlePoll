using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Smab.DoodlePoll.Models;

namespace Smab.DoodlePoll
{
	public class DoodlePollService : DoodlePollRepository, IDoodlePollService
	{
		public List<Poll> GetList() => throw new NotImplementedException();
	}
}
