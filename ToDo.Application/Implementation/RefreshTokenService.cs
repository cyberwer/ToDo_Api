using ToDo.Application.Contracts;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.RepositoryInterface;

namespace ToDo.Application.Implementation
{
	public class RefreshTokenService(
		IRefreshTokenRepository _refreshTokenRepository) : IRefreshTokenService
	{

		public async Task<RefreshTokenDomain> GetRefreshTokenById(Guid id)
		{
			return await _refreshTokenRepository.GetRefreshTokenById(id);
		}
	}
}
