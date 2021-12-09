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
	public class MessageController : Controller
	{
		public IMessageRepository messageRepository;

		public MessageController(IMessageRepository repository)
		{
			messageRepository = repository;
		}

		[HttpPost]
		public IActionResult SendMessage([FromBody]Messages msg)
		{
			messageRepository.SendMessage(msg);
			return Ok();
		}
	}
}
