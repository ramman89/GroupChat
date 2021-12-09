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
	public class GroupController : ControllerBase
	{
		public IGroupRepository groupRepository;
		public GroupController(IGroupRepository repository)
		{
			groupRepository = repository;
		}
		[HttpGet]
		public IActionResult Get(int id)
		{
			return Ok(groupRepository.GetGroup(id));
		}

		[HttpPost]
		public IActionResult Post([FromBody]Group Group)
		{
			groupRepository.CreateGroup(Group);
			return Ok();
		}

		[HttpPut]
		public IActionResult Put([FromBody] Group Group)
		{
			groupRepository.UpdateGroup(Group);
			return Ok();
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			groupRepository.DeleteGroup(id);
			return Ok();
		}
	}
}
