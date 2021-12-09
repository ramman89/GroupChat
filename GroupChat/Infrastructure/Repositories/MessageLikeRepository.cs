using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public class MessageLikeRepository : IMessageLikeRepository
	{
		GCdbcontext GCcontext;
		public MessageLikeRepository(GCdbcontext dbcontext)
		{
			GCcontext = dbcontext;
		}
		public void LikeMessage(MessageLike messageLike)
		{
			GCcontext.MessageLikes.Add(messageLike);
			GCcontext.SaveChanges();
		}
	}
}
