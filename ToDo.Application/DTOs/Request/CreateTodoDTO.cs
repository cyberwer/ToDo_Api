namespace ToDo.Application.DTOs.Request
{
	public record CreateTodoDTO(
	string name,
	string description,
	List<CreateTodoItemsDTO> Items);

}
