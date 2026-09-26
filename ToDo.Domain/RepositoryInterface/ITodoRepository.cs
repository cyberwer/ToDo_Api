using ToDo.Domain.DomainEntities;

namespace ToDo.Domain.RepositoryInterface
{
	public interface ITodoRepository : IGenericRepository<TodoListDomain>
	{
		Task<List<TodoListDomain>> GetTodosAsync(Guid userId);
	}
}
