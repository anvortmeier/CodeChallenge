using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;
using CodeChallenge.Services;

namespace CodeChallenge.Controllers
{
	
	[Produces("application/json")]
	[Route("api/Follower")]
	public class FollowersController : Controller
	{
		[HttpGet("{githubID}")]
		public IEnumerable<FollowerModel> GetFollowers(string githubID)
		{
			var followers = new FollowersService(githubID);
			return followers.ViewFollowersById();
		}
	}
}
