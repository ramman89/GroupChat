using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public interface IMessageLikeRepository
	{
		public void LikeMessage(MessageLike messageLike);
	}
}
