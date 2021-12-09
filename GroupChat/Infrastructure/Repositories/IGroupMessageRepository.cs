using GroupChat.Infrastructure.Entites;
using GroupChat.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public interface IGroupMessageRepository
	{
		public GroupMessages GetGroupMessages(int groupId);
	}
}
