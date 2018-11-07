using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Models;
using CodeChallenge.Services;

namespace CodeChallenge.Controllers
{
	
	[Produces("application/json")]
	[Route("api/User")]
	public class UsersController : Controller
	{
		[HttpGet]
		public IEnumerable<RootObject> GetAllUsers()
		{
			var users = new UsersService();
			return users.ViewUsers();
		}
	}
}
