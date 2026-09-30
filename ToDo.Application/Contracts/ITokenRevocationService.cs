namespace ToDo.Application.Contracts
{
	public interface ITokenRevocationService
	{
		Task<bool> IsSessionRevokedAsync(Guid sessionId);
		Task InvalidateSessionCacheAsync(Guid sessionId);
	}
}
