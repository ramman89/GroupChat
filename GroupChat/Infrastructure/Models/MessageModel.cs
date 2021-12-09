using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Models
{
	public class MessageModel
	{
		public string Message { get; set; }

		public int MessageBy { get; set; }

		public IEnumerable<int> LikesBy { get; set; }
	}
}
