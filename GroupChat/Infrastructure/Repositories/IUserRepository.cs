using GroupChat.Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChat.Infrastructure.Repositories
{
	public interface IUserRepository
	{
		public User GetUser(int id);
		public void CreateUser(User user);
		public void UpdateUser(User user);
		public void DeleteUser(int id);

	}
}
