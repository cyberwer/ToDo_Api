using AutoMapper;
using ToDo.Domain.DomainEntities;
using ToDo.Intrastructure.Persistence.Entities;

namespace ToDo.Intrastructure.Mapper
{
	public class UserMappingExtension : Profile
	{
		public UserMappingExtension()
		{
			CreateMap<User, UserDomain>().ReverseMap();  //entity to domain and domain to entity. Bidirectional
		}
	}
}
