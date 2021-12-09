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
	public class LikeMessageController : ControllerBase
	{
		public IMessageLikeRepository messageLikeRepository;

		public LikeMessageController(IMessageLikeRepository repository)
		{
			messageLikeRepository = repository;
		}

		[HttpPost]
		public IActionResult GetGroupMessages([FromBody] MessageLike messageLike)
		{
			messageLikeRepository.LikeMessage(messageLike);
			return Ok();
		}
	}
}
