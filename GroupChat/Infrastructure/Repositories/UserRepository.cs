using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		GCdbcontext GCcontext;
		public UserRepository(GCdbcontext dbcontext)
		{
			GCcontext = dbcontext;
		}
		public void CreateUser(User user)
		{
			GCcontext.Users.Add(user);
			GCcontext.SaveChanges();
		}

		public void DeleteUser(int id)
		{
			var user = GetUser(id);
			user.IsDeleted = true;
			UpdateUser(user);
		}

		public User GetUser(int id)
		{
			return GCcontext.Users.FirstOrDefault(x => x.Id == id);
		}

		public void UpdateUser(User user)
		{
			GCcontext.Set<User>().Update(user);
			GCcontext.SaveChanges();
		}
	}
}
