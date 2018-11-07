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
			var repos = LimitReposToThree(githubId);
			foreach(var repoA in repos)
			{
				string repoIdA = repoA.id.ToString();
				repoA.repos = LimitReposToThree(repoIdA).ToList();

				foreach (var repoB in repoA.repos)
				{
					string repoIdB = repoB.id.ToString();
					repoB.repos = LimitReposToThree(repoIdA).ToList();
				}
			}

			return repos;
		}

		private IEnumerable<RepoModel> LimitReposToThree(string id)
		{
			return client.GetGithubIdRepos(githubId).Take(3);
		}
	}
}
