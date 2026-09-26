using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ToDo.Domain.RepositoryInterface;
using ToDo.Intrastructure.Persistence.Entities;

namespace ToDo.Intrastructure.Repository
{
	public class GenericRepository<TDomain, TEntity> : IGenericRepository<TDomain>
	   where TDomain : class
	   where TEntity : class
	{
		protected readonly AppDbContext _appDbContext;
		protected readonly IMapper _mapper;

		public GenericRepository(AppDbContext appDbContext,
			IMapper mapper)
		{
			_appDbContext = appDbContext;
			_mapper = mapper;
		}

		public async Task AddAsync(TDomain domain)
		{
			var entity = _mapper.Map<TEntity>(domain); // domain --> enttity

			await _appDbContext.Set<TEntity>().AddAsync(entity);
		}

		public async Task UpdateAsync(TDomain domain)
		{
			var entity = _mapper.Map<TEntity>(domain); // domain --> entity

			_appDbContext.Set<TEntity>().Update(entity);
		}

		public async Task<int> CommitAsync()
		{
			return await _appDbContext.SaveChangesAsync();
		}

		public async Task<IEnumerable<TDomain>> GetAllAsync()
		{
			return await _appDbContext.Set<TEntity>()
				.ProjectTo<TDomain>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<TDomain?> GetByIdAsync(object id)
		{
			var entity = await _appDbContext.Set<TEntity>().FindAsync(id); // id shd be primary key

			return entity == null ? null : _mapper.Map<TDomain>(entity); // enttity---> domain
		}

		public async Task DetachAsync(object entityId)
		{
			var entity = _appDbContext.Set<TEntity>().Find(entityId);
			if (entity != null)
			{
				_appDbContext.Entry(entity).State = EntityState.Detached;
			}
			await Task.CompletedTask;
		}
	}

}
