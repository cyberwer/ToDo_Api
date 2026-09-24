using Microsoft.EntityFrameworkCore;
using ToDo.Intrastructure.Persistence.Entities;


namespace ToDo.Api
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuruation)
		{
			var connectionString = configuruation.GetConnectionString("DatabaseConnection");

			services.AddDbContext<AppDbContext>(options =>
			{
				options.UseSqlServer(connectionString);
			});


			return services;
		}

	}
}
