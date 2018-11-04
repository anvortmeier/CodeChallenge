using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
	public class CodeChallengeService
	{
		private readonly HttpClient httpClient;

		public CodeChallengeService()
		{
			httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			httpClient.DefaultRequestHeaders.Add("User-Agent", "anvortmeier");
		}

		public IEnumerable<FollowerModel> GetGithubIdFollowers(string githubId)
		{
			try
			{
				var followers = httpClient.GetAsync(new Uri($"https://api.github.com/users/{githubId}/followers")).Result;
				return followers.Content.ReadAsAsync<List<FollowerModel>>().Result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

		public IEnumerable<RepoModel> GetGithubIdRepos(string githubId)
		{
			try
			{
				var repos = httpClient.GetAsync(new Uri($"https://api.github.com/users/{githubId}/repos")).Result;
				return repos.Content.ReadAsAsync<List<RepoModel>>().Result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

		public IEnumerable<StargazerModel> GetGithubIdRepoStargazers(string githubId, string repo)
		{
			try
			{
				var stargazers = httpClient.GetAsync(new Uri($"https://api.github.com/repos/{githubId}/{repo}/stargazers")).Result;
				return stargazers.Content.ReadAsAsync<List<StargazerModel>>().Result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}


		public IEnumerable<FollowerModel> GetGithubUsers()
		{
			try
			{
				var users = httpClient.GetAsync(new Uri($"https://api.github.com/users")).Result;
				return users.Content.ReadAsAsync<List<FollowerModel>>().Result;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

	}
}
