using AutoMapper;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Requests;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.RepositoryInterface;

namespace ToDo.Application.Implementation
{
	public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
	{
		//this conts method can be replaces by adding DI (IUserRepository userRepository) in the class level  NET 10

		//private readonly IUserRepository userRepository;	

		//public UserService(IUserRepository userRepository)
		//{
		//		this.userRepository = userRepository;
		//}
		public async Task<bool> CreateUserAsync(CreateUserDTO userDTO)
		{
			// get password hash from password (use BCRYPT nuget package)
			var userDomain = mapper.Map<UserDomain>(userDTO);
			userDomain.PasswordHash =  BCrypt.Net.BCrypt.HashPassword(userDomain.PasswordHash);

			//convert DTO to Domain
			await userRepository.AddAsync(userDomain);

			var response = await userRepository.CommitAsync();

			return response > 0;
			
		}
	}
}
