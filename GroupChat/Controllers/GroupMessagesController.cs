using GroupChat.Infrastructure.Models;
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
	public class GroupMessagesController : Controller
	{
		public IGroupMessageRepository groupMessageRepository;

		public GroupMessagesController(IGroupMessageRepository repository)
		{
			groupMessageRepository = repository;
		}

		[HttpGet]
		public IActionResult GetGroupMessages(int groupId)
		{
			return Ok(groupMessageRepository.GetGroupMessages(groupId));
		}
	}
}
