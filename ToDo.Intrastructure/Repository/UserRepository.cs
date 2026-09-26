using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.RepositoryInterface;
using ToDo.Intrastructure.Persistence.Entities;

namespace ToDo.Intrastructure.Repository
{

	public class UserRepository : GenericRepository<UserDomain, User>, IUserRepository
	{
		public UserRepository(AppDbContext appDbContext,IMapper _mapper) : base(appDbContext, _mapper)
		{

		}

		public async Task<UserDomain> GetByEmailAsync(
			string emailAddress)
		{

			var user =
				await _appDbContext.Users.FirstOrDefaultAsync(
						x => x.Email == emailAddress);

			return _mapper.Map<UserDomain>(user);
		}
	}

}
