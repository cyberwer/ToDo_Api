using ToDo.Domain.DomainEntities;

namespace ToDo.Application.Contracts
{
	public interface IRefreshTokenService
	{
		Task<RefreshTokenDomain> GetRefreshTokenById(Guid id);
	}

	



}
