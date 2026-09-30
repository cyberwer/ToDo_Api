using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;
using ToDo.Domain.DomainEntities;

namespace ToDo.Application.Mapper
{
	public static class TodoMappingExtension
	{
		extension(CreateTodoDTO todo)
		{
			public TodoListDomain ConvertToTodoListDomain()
			{
				return new TodoListDomain()
				{
					Description = todo.description,
					Name = todo.name,
					TodoItems = todo.Items.Select(x => new TodoItemDomain()
					{
						Description = x.description,
						Title = x.title,
						Priority = x.priority,
						DueDate = x.dueDate,
						ReminderDate = x.remiderDate,
					})
					.ToList()
				};
			}
		}

		extension(TodoListDomain source)
		{
			public TodoResponseDTO ToResponseDTO() =>
				new(
					Name: source.Name,
					Description: source.Description,
					Metadata: source.TodoItems
						.Select(item => item.ToMetadata())
						.ToList()
				);
		}

		extension(TodoItemDomain source)
		{
			public TodoMetadata ToMetadata() =>
				new(
					Title: source.Title,
					Description: source.Description,
					Priority: source.Priority.ToString(),
					Status: source.Status.ToString(),
					DueDate: source.DueDate
				);
		}

		extension(IEnumerable<TodoListDomain> source)
		{
			public List<TodoResponseDTO> ToResponseDTO() =>
				source.Select(todo => todo.ToResponseDTO()).ToList();

		}
	}
}
