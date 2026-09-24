using Microsoft.EntityFrameworkCore;


namespace ToDo.Intrastructure.Persistence.Entities
{
	public class AppDbContext : DbContext
	{

		//rivate readonly ICurrentUserService _currentUser;
		public AppDbContext(
		   DbContextOptions<AppDbContext> options //ICurrentUserService currentUser
			) : base(options)
		{
			//_currentUser = currentUser;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<TodoList> ToDoLists { get; set; }
		public DbSet<TodoItem> ToDoItems { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TodoItemTag> ToDoItemTags { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<ActivityLog> ActivityLogs { get; set; }

	}

}


