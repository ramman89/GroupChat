using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupChat.Infrastructure.Entites;

namespace GroupChat.Infrastructure
{
	public class GCdbcontext: DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Messages> Messages { get; set; }
		public DbSet<MessageLike> MessageLikes { get; set; }
		public GCdbcontext(string connectionstring):base(GetOptions(connectionstring))
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>().ToTable("rUsers");
			modelBuilder.Entity<Group>().ToTable("rGroups");
			modelBuilder.Entity<Messages>().ToTable("rMessages");
			modelBuilder.Entity<MessageLike>().ToTable("rMessageLikes");

			modelBuilder.Entity<Group>().HasMany(x => x.Messages).WithOne(x => x.Group).HasForeignKey(x => x.GroupId);
			modelBuilder.Entity<Messages>().HasMany(x => x.MessageLikes).WithOne(x => x.Messages).HasForeignKey(x => x.MessageId);



		}
		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
		}
	}
}
