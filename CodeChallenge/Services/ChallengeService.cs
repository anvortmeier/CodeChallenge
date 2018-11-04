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
