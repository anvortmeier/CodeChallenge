using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;
using CodeChallenge.Services;

namespace CodeChallenge.Controllers
{
	
	[Produces("application/json")]
	[Route("api/Stargazers")]
	public class StargazerController : Controller
	{
		[HttpGet("{githubID}")]
		public IEnumerable<StargazerModel> GetStargazers(string githubID, [FromBody] IEnumerable<RepoNameModel> repo)
		{
			var stargazers = new StargazerService(githubID, repo);
			return stargazers.ViewStargazersByRepoAndId();
		}
	}
}
