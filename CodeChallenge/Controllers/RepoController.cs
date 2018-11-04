using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;
using CodeChallenge.Services;

namespace CodeChallenge.Controllers
{
	[Produces("application/json")]
	[Route("api/Repo")]
	public class RepoController : Controller
	{
		[HttpGet("{githubId}")]
		public IEnumerable<RepoModel> GetRepos(string githubId)
		{
			var repos = new RepoService(githubId);
			return repos.ReposbyId();
		}
	}
}
