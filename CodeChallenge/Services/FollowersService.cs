using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class FollowersService
	{
		private readonly CodeChallengeService client;
		private readonly string githubId;

		public FollowersService(string githubId)
		{
			this.githubId = githubId;
			client = new CodeChallengeService();
		}

		public IEnumerable<RootObject> ViewFollowers()
		{
			var followers = LimitFollowersToFive(githubId);
			foreach(var followerA in followers)
			{
				followerA.followers = LimitFollowersToFive(followerA.id.ToString()).ToList();
				foreach(var followerB in followerA.followers)
				{
					followerB.followers = LimitFollowersToFive(followerB.id.ToString()).ToList();
				}
			}

			return followers;
		}

		private IEnumerable<RootObject> LimitFollowersToFive(string githubID )
		{
			return client.GetGithubIdFollowers(githubId).Take(5);
		}
	}
}
