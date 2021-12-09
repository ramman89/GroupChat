using GroupChat.Infrastructure.Entites;
using GroupChat.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public class GroupMessageRepository : IGroupMessageRepository
	{
		GCdbcontext GCcontext;
		public GroupMessageRepository(GCdbcontext dbcontext)
		{
			GCcontext = dbcontext;
		}
		public GroupMessages GetGroupMessages(int groupId)
		{
			var data = GCcontext.Groups.Include(x => x.Messages).Include(x => x.Messages).ThenInclude(c=>c.MessageLikes).FirstOrDefault(x => x.Id == groupId);
			GroupMessages groupMessages = new GroupMessages();
			groupMessages.Description = data.Description;
			groupMessages.Name = data.Name;
			groupMessages.messages = data.Messages.Select(x => new MessageModel() { Message = x.Body, MessageBy = x.MessageBy, LikesBy = x?.MessageLikes.Select(y => y.UserId) }).ToList();
			return groupMessages;
		}
	}
}
