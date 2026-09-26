using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using ToDo.Application;
using ToDo.Application.Contracts;
using ToDo.Application.Implementation;
using ToDo.Domain.RepositoryInterface;
using ToDo.Intrastructure;
using ToDo.Intrastructure.Persistence.Entities;
using ToDo.Intrastructure.Repository;


namespace ToDo.Api
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuruation)
		{
			//var connectionString = configuruation.GetConnectionString("LocalDbConnection");

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(configuruation.GetConnectionString("LocalDbConnection"));
			});

			services.AddAutoMapper(typeof(InfraAssemblyMaker).Assembly); //register automaer on at ingra layer

			services.AddScoped<IUserRepository, UserRepository>();

			return services;
		}

		//Adding Interfac service to DI
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//
			services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly); //register automaer on at Service layer

			services.AddScoped<IUserService, UserService>();




			return services;
		}		 

	}
}
