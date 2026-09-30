using ToDo.Domain.Enums;

namespace ToDo.Application.DTOs.Request
{
	public record CreateTodoItemsDTO(
	string title,
	string description,
	TodoPriority priority,
	DateTime dueDate,
	DateTime remiderDate
	);

}
