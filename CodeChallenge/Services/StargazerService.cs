using System.Collections.Generic;
using System.Linq;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class StargazerService
	{
		private readonly CodeChallengeService client;
		private readonly string githubId;
		private readonly IEnumerable<RepoNameModel> repo;

		public StargazerService(string githubId, IEnumerable<RepoNameModel> repo)
		{
			this.githubId = githubId;
			this.repo = repo;
			client = new CodeChallengeService();
		}

		public IEnumerable<StargazerModel> ViewStargazersByRepoAndId()
		{
			return LimitStargazersByRepo();
		}

		private IEnumerable<StargazerModel> LimitStargazersByRepo()
		{
			var stargazers = new List<StargazerModel>();

			foreach(var repository in repo)
			{
				stargazers.AddRange(LimitStargazersToThreePerRepo(repository.Repo));
			}

			return stargazers;
		}

		public IEnumerable<StargazerModel> LimitStargazersToThreePerRepo(string repo)
		{
			return client.GetGithubIdRepoStargazers(githubId, repo);
		}
	}
}
