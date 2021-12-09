using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Entites
{
	[DataContract]
	[Serializable]
	public class BaseEntity
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedOn { get; set; }

		public BaseEntity()
		{
			CreatedOn = DateTime.Now;
		}
	}

	public class User : BaseEntity
	{
		public string FirstName { get; set; }

		public string SecondName { get; set; }

		public string Email { get; set; }

		public string Mobile { get; set; }
	}

	[DataContract]
	[Serializable]
	public class Group : BaseEntity
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Messages> Messages { get; set; }
	}

	public class Messages : BaseEntity
	{
		public Messages()
		{
			MessageLikes = new List<MessageLike>();
		}
		public string Body { get; set; }

		public int GroupId { get; set; }
		public virtual Group Group { get; set; }
		public int MessageBy { get; set; }
		public virtual ICollection<MessageLike> MessageLikes { get; set; }
	}

	public class MessageLike: BaseEntity
	{
		public int MessageId { get; set; }
		public int UserId { get; set; }
		public virtual Messages Messages { get; set; }
		public virtual List<User> LikesBy { get; set; }
	}
}
