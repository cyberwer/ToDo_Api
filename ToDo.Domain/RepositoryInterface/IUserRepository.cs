using ToDo.Domain.DomainEntities;

namespace ToDo.Domain.RepositoryInterface
{

	public interface IUserRepository : IGenericRepository<UserDomain>
	{
		Task<UserDomain> GetByEmailAsync(string emailAddress);
	}
}
