using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public class MessageRepository : IMessageRepository
	{
		GCdbcontext GCcontext;
		public MessageRepository(GCdbcontext dbcontext)
		{
			GCcontext = dbcontext;
		}
		public void SendMessage(Messages msg)
		{
			GCcontext.Messages.Add(msg);
			GCcontext.SaveChanges();
		}
	}
}
