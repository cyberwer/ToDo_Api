using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.RepositoryInterface;
using ToDo.Intrastructure.Persistence.Entities;

namespace ToDo.Intrastructure.Repository
{
	public class TodoRepository :
	   GenericRepository<TodoListDomain, TodoList>, ITodoRepository
	{
		private readonly AppDbContext appDbContext;

		public TodoRepository(
			AppDbContext appDbContext,
			IMapper mapper)
			: base(appDbContext, mapper)
		{
			this.appDbContext = appDbContext;
		}

		public async Task<List<TodoListDomain>> GetTodosAsync(Guid userId)
		{
			var todoItems
				= await appDbContext.ToDoLists
					.Include(x => x.TodoItems)
					.Where(x => x.UserId == userId)
					.ToListAsync();

			return _mapper.Map<List<TodoListDomain>>(todoItems);
		}
	}

}
