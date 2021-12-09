using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public interface IGroupRepository
	{
		public Group GetGroup(int id);
		public void CreateGroup(Group Group);
		public void UpdateGroup(Group Group);
		public void DeleteGroup(int id);
	}
}
