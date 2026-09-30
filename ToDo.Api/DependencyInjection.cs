using Microsoft.EntityFrameworkCore;
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

			//Repository DI
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ITodoRepository, TodoRepository>();
			services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

			return services;
		}

		//Adding Interfac service to DI
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			//register automaer on at Service layer
			services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly); 

			//Services DI
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICurrentUserService, CurrentUserService>();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<ITodoService, TodoService>();
			services.AddScoped<IPasswordHasher, PasswordHasher>();
			services.AddScoped<IEmailService, EmailService>();
			services.AddScoped<ITokenRevocationService, TokenRevokationService>();
			services.AddScoped<IRefreshTokenService, RefreshTokenService>();



			return services;
		}		 

	}
}
