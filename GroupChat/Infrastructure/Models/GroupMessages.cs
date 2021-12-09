using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Models
{
	public class GroupMessages
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<MessageModel> messages { get; set; }


	}
}
