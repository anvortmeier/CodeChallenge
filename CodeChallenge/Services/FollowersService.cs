using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class FollowersService
	{
		private readonly CodeChallengeService client;
		private readonly int DEFAULT_DEPTH = 3;
		private string githubId;

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
				string githubIdA = followerA.id.ToString();
				followerA.followers = LimitFollowersToFive(githubIdA).ToList();
				foreach(var followerB in followerA.followers)
				{
					string githubIdB = followerB.id.ToString();
					followerB.followers = LimitFollowersToFive(githubIdB).ToList();
				}
				
			}

			return followers;
		}

		public IEnumerable<RootObject> ViewFollowers(string id)
		{
			return ViewFollowers(id, DEFAULT_DEPTH);
		}

		public IEnumerable<RootObject> ViewFollowers(string id, int depth)
		{
			var followers = LimitFollowersToFive(id).ToList();
			if (depth == 0) { return followers; }
			else
			{
				foreach (var follower in followers)
				{
					string githubId = follower.id.ToString();
					ViewFollowers(githubId, depth - 1);
				}
			}
			return followers;
		}

		private IEnumerable<RootObject> LimitFollowersToFive(string githubID )
		{
			//return client.GetGithubIdFollowers(githubId).Take(5);
			return client.GetGithubIdFollowers(githubId).Take(2);
		}
	}
}
