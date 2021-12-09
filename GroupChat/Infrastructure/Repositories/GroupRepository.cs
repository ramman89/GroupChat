using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public class GroupRepository : IGroupRepository
	{
		GCdbcontext GCcontext;

		public GroupRepository(GCdbcontext dbcontext)
		{
			GCcontext = dbcontext;
		}
		public void CreateGroup(Group Group)
		{
			GCcontext.Set<Group>().Add(Group);
			GCcontext.SaveChanges();
		}

		public void DeleteGroup(int id)
		{
			var group = GetGroup(id);
			group.IsDeleted = true;
			UpdateGroup(group);

		}

		public Group GetGroup(int id)
		{
			return GCcontext.Set<Group>().FirstOrDefault(x => x.Id == id);
		}


		public void UpdateGroup(Group Group)
		{
			GCcontext.Set<Group>().Update(Group);
			GCcontext.SaveChanges();
		}
	}
}
