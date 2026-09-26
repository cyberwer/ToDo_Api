using ToDo.Application.DTOs.Requests;

namespace ToDo.Application.Contracts
{
	public interface IUserService
	{
		Task<bool> CreateUserAsync(CreateUserDTO userDTO);
	}
}
