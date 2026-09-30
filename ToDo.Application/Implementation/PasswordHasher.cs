using ToDo.Application.Contracts;

namespace ToDo.Application.Implementation
{
	public class PasswordHasher : IPasswordHasher
	{
		public string Hash(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password);
		}

		public bool VerifyPassword(string password, string passwordHash)
		{
			return BCrypt.Net.BCrypt.Verify(password, passwordHash);
		}
	}
}
