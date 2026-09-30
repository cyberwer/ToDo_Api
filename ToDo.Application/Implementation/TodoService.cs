using ToDo.Application.Common;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;
using ToDo.Application.Mapper;
using ToDo.Domain.RepositoryInterface;

namespace ToDo.Application.Implementation
{
	public class TodoService : ITodoService
	{
		private readonly ITodoRepository _todoRepository;
		private readonly ICurrentUserService _currentUserService;

		public TodoService(
			ITodoRepository todoRepository,
			ICurrentUserService currentUserService)
		{
			_todoRepository = todoRepository;
			_currentUserService = currentUserService;
		}

		public async Task<Result> CreateTodoAsync(
			CreateTodoDTO todos)
		{
			var todo
				= todos.ConvertToTodoListDomain();

			todo.UserId = Guid.Parse(_currentUserService.GetCurrentUserId());

			await _todoRepository.AddAsync(todo);

			int rowsInserted = await _todoRepository.CommitAsync();

			return rowsInserted > 0
			   ? Result.Success()
			   : Result.Failure(Error.Failure("Todo.CreateFailed", "Could not create the todo item."));
		}

		public async Task<Result<List<TodoResponseDTO>>> GetItems()
		{
			var todoItemsDomain
				   = await _todoRepository.GetTodosAsync(Guid.Parse(_currentUserService.GetCurrentUserId()));

			return Result.Success(todoItemsDomain.ToResponseDTO());
		}
	}
}