using System.Threading.Tasks;
using Smab.DoodlePoll.Models;

namespace Smab.DoodlePoll
{
	public interface IDoodlePollRepository
    {
		Task<Poll> GetByIdAsync(string id);
	}
}
