using AutoMapper;
using ToDo.Application.DTOs.Requests;
using ToDo.Domain.DomainEntities;

namespace ToDo.Application.Mapper
{
	public static class UserMappingExtension
	{
		extension(CreateUserDTO user)
		{
			public UserDomain ToUserDomain()
			{
				return new UserDomain()
				{
					Email = user.Email,
					FullName = user.FullName,
					PasswordHash = user.Password
				};
			}
		}
	}
}
