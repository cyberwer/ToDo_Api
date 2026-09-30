using AutoMapper;
using ToDo.Domain.DomainEntities;
using ToDo.Intrastructure.Persistence.Entities;

namespace ToDo.Intrastructure.Mapper
{
	/// <summary>
	/// AutoMapper profile for RefreshToken entity and domain model mapping.
	/// </summary>
	public class RefreshTokenMappingExtension : Profile
	{
		public RefreshTokenMappingExtension()
		{
			CreateMap<RefreshTokenDomain, RefreshToken>()
				.ReverseMap();
		}
	}
}

