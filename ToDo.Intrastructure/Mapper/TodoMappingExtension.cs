using AutoMapper;
using ToDo.Domain.DomainEntities;
using ToDo.Intrastructure.Persistence.Entities;

namespace ToDo.Intrastructure.Mapper
{
	public class TodoMappingExtension : Profile
	{
		public TodoMappingExtension()
		{
			CreateMap<TodoItemDomain, TodoItem>()
				.ForMember(dest => dest.Priority, opt
					=> opt.MapFrom(src => (int)src.Priority))
				.ForMember(dest => dest.Status, opt
					=> opt.MapFrom(src => (int)src.Status)).ReverseMap();

			CreateMap<TodoListDomain, TodoList>()
				.ForMember(dest => dest.UserId, opt
					=> opt.MapFrom(src => src.UserId))
				.ReverseMap();


		}
	}
}