﻿using System.Collections.Generic;
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

		public IEnumerable<FollowerModel> ViewFollowersById()
		{
			return LimitFollowersToFive();
		}

		private IEnumerable<FollowerModel> LimitFollowersToFive()
		{
			return client.GetGithubIdFollowers(githubId).Take(5);
		}
	}
}
