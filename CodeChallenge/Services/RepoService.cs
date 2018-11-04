using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class RepoService
	{
		private readonly CodeChallengeService client;
		private readonly string githubId;

		public RepoService(string githubId)
		{
			this.githubId = githubId;
			client = new CodeChallengeService();
		}

		public IEnumerable<RepoModel> ReposbyId()
		{
			return LimitReposToThree();
		}

		private IEnumerable<RepoModel> LimitReposToThree()
		{
			return client.GetGithubIdRepos(githubId).Take(3);
		}
	}
}
