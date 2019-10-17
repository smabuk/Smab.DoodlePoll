using System.Text.Json.Serialization;
using System.Threading;

namespace Smab.DoodlePoll.Models
{
	public class AutoIncrementBase
	{
		private static int nextIndex;

		[JsonPropertyName("index")]
		public int Index { get; set; }

		public AutoIncrementBase()
		{
			Index = Interlocked.Increment(ref nextIndex);
		}
	}
}
