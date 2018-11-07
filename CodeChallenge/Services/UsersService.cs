using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class UsersService
	{
		private readonly CodeChallengeService client;
		private readonly string githubId;

		public UsersService()
		{
			client = new CodeChallengeService();
		}

		public IEnumerable<RootObject> ViewUsers()
		{
			return client.GetGithubUsers();
		}
	}
}
