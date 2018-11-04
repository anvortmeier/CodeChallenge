using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class FollowersService
	{
		private readonly CodeChallengeService client;
		private readonly string gitId;

		public FollowersService(string gitId)
		{
			this.gitId = gitId;
			client = new CodeChallengeService();
		}

		public IEnumerable<FollowerModel> ViewFollowersById()
		{
			return LimitFollowersToFive();
		}

		private IEnumerable<FollowerModel> LimitFollowersToFive()
		{
			return client.GetGithubIdFollowers(gitId).Take(5);
		}
	}
}
