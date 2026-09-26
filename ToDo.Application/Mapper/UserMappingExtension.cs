using AutoMapper;
using ToDo.Application.DTOs.Requests;
using ToDo.Domain.DomainEntities;

namespace ToDo.Application.Mapper
{
	public class UserMappingExtension : Profile
	{
		public UserMappingExtension()
		{
			//get the password has from the password
			CreateMap<CreateUserDTO, UserDomain>()
				.ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.password));
		}
	}
}
