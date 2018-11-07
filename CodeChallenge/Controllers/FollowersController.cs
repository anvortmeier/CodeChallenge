using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;
using CodeChallenge.Services;

namespace CodeChallenge.Controllers
{
	
	[Produces("application/json")]
	[Route("api/Followers")]
	public class FollowersController : Controller
	{
		[HttpGet("{githubID}")]
		public IEnumerable<RootObject> GetFollowers(string githubID)
		{
			var followers = new FollowersService(githubID);
			return followers.ViewFollowers();
		}
	}
}
