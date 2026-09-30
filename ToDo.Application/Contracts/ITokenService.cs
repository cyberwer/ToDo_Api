using ToDo.Application.Common;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;

namespace ToDo.Application.Contracts
{
	public interface ITokenService
	{

		Task<Result<TokenResponseDTO>> GetTokenAsync(TokenRequestDTO requestDto);

		Task<Result<TokenResponseDTO>> RefreshTokenAsync(
			RefreshTokenRequestDTO requestDto, string? clientIp = null);

		Task<Result> RevokeTokenAsync(string refreshToken, string? clientIp = null);

		Task<bool> RevokeAllUserTokensAsync(Guid userId, string? clientIp = null);
	}

}
