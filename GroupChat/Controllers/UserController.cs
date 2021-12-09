using GroupChat.Infrastructure.Entites;
using GroupChat.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		public IUserRepository userRepository;
		public UserController(IUserRepository repository)
		{
			userRepository = repository;
		}
		[HttpGet]
		public IActionResult Get(int id)
		{
			return Ok(userRepository.GetUser(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody] User user)
		{
			userRepository.CreateUser(user);
			return Ok();
		}

		[HttpPut]
		public IActionResult Put([FromBody] User user)
		{
			userRepository.UpdateUser(user);
			return Ok();
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			userRepository.DeleteUser(id);
			return Ok();
		}
	}
}
