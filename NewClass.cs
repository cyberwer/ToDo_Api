namespace ToDo.Intrastructure.Persistence.Entities

using System;
using System.Collections.Generic;

public class User : BaseAuditableEntity
{
	public string FullName { get; set; }
	public string Email { get; set; }
	public string PasswordHash { get; set; }
}

public abstract class BaseAuditableEntity : BaseEntity
{
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	public DateTime? UpdatedAt { get; set; }
	public string CreatedById { get; set; }
	public string? UpdatedById { get; set; }

}

internal class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{

	}

	public DbSet<User> Users { get; set; }
	public DbSet<ToDoList> ToDoLists { get; set; }
	public DbSet<ToDoItem> ToDoItems { get; set; }
	public DbSet<Tag> Tags { get; set; }
	public DbSet<ToDoItemTag> ToDoItemTags { get; set; }
	public DbSet<Comment> Comments { get; set; }
	public DbSet<ActivityLog> ActivityLogs { get; set; }

}

public abstract class BaseEntity
{
	public Guid Id { get; set; } = Guid.NewGuid();
}

public class Comment
{

}

public class Tag
{
}

public class ToDoItem : BaseAuditableEntity
{
	public Guid TodoListId { get; set; }
	public ToDoList ToDoList { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public int Priority { get; set; }
	public int Status { get; set; }
	public DateTime? DueDate { get; set; }
	public DateTime? ReminderDate { get; set; }
	public DateTime? CompletedAt { get; set; }
	public bool IsDeleted { get; set; }

	public ICollection<ToDoItemTag> ToDoItemTags { get; set; }
	public ICollection<Comment> Comments { get; set; }

}

public class ToDoItemTag
{

}

public class ToDoList
{

}

