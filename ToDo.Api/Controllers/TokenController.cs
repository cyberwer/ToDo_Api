using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Extensions;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;

namespace ToDo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController(
		ITokenService tokenService,
		IHttpContextAccessor _httpContextAccessor) : ControllerBase
	{

		[HttpPost]
		public async Task<IActionResult> Get(TokenRequestDTO requestDto)
		{
			var response =
				await tokenService.GetTokenAsync(requestDto);

			return Ok(response);
		}


		[HttpPost("refresh")]
		public async Task<IActionResult> RefreshToken(RefreshTokenRequestDTO requestDto)
		{
			var clientIp = GetClientIpAddress();
			var result = await tokenService.RefreshTokenAsync(requestDto, clientIp);

			if (result.IsSuccess)
				return Ok(result.Value);

			return result.ToProblemDetails();
		}


		[HttpPost("revoke")]
		public async Task<IActionResult> Revoke(RefreshTokenRequestDTO requestDto)
		{
			var clientIp = GetClientIpAddress();
			var result = await tokenService.RevokeTokenAsync(requestDto.refreshToken, clientIp);

			if (result.IsSuccess)
				return Ok("Token revoked");

			return result.ToProblemDetails();
		}


		private string? GetClientIpAddress()
		{
			var context = _httpContextAccessor.HttpContext;
			if (context == null)
				return null;

			// Check X-Forwarded-For header first (for proxy scenarios)
			if (context.Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedFor))
			{
				var ip = forwardedFor.ToString().Split(',').FirstOrDefault()?.Trim();
				if (!string.IsNullOrWhiteSpace(ip))
					return ip;
			}

			// Fall back to RemoteIpAddress
			return context.Connection.RemoteIpAddress?.ToString();
		}
	}
}
