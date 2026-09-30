using AutoMapper;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Requests;
using ToDo.Domain.DomainEntities;
using ToDo.Domain.RepositoryInterface;

namespace ToDo.Application.Implementation
{
	public class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
	{
		//this conts method can be replaces by adding DI (IUserRepository userRepository) in the class level  NET 10

		//private readonly IUserRepository userRepository;	

		//public UserService(IUserRepository userRepository)
		//{
		//		this.userRepository = userRepository;
		//}
		public async Task<bool> CreateUserAsync(CreateUserDTO userDTO)
		{
			// get password hash from password (use BCRYPT nuget package)
			var userDomain = mapper.Map<UserDomain>(userDTO);
			userDomain.PasswordHash =  BCrypt.Net.BCrypt.HashPassword(userDomain.PasswordHash);

			//convert DTO to Domain
			await userRepository.AddAsync(userDomain);

			var response = await userRepository.CommitAsync();

			return response > 0;

		}

		private string EmailTemplate(
			string userName)
		{
			return $"""
                    <html>
                    <head>

                    </head>
                    <body>
                        <div class="header">
                            <h1>Welcome to Our Todo App!</h1>
                        </div>
                        <div class="content">
                            <p>Hello {userName},</p>
                            <p>Thank you for joining our Todo application. We're excited to help you stay organized and productive.</p>
                            <p>Here's what you can do:</p>
                            <ul>
                                <li>Create and manage your daily tasks</li>
                                <li>Set priorities and deadlines</li>
                                <li>Track your progress</li>
                                <li>Collaborate with your team</li>
                            </ul>
                            <p>If you have any questions, feel free to reach out to our support team.</p>
                            <p>Best regards,<br>The Todo Team</p>
                        </div>
                        <div class="footer">
                            <p>&copy; 2026 Todo Application. All rights reserved.</p>
                        </div>
                    </body>
                    </html>
                    """;
		}
	}
}
