using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smab.DoodlePoll.Models;

namespace Smab.DoodlePoll
{
    public interface IDoodlePollService : IDoodlePollRepository
    {
		List<Poll> GetList();
	}
}
