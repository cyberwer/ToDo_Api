using ToDo.Application.Common;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;

namespace ToDo.Application.Contracts
{
	public interface ITodoService
	{
		Task<Result> CreateTodoAsync(CreateTodoDTO createToDoTDO);

		Task<Result<List<TodoResponseDTO>>> GetItems();
	}

	



}
