using ToDo.Application.Constants;
using ToDo.Application.Contracts;

namespace ToDo.Application.Implementation
{
	public class EmailService(
	  IHttpClientFactory clientFactory) : IEmailService
	{
		public async Task<bool> SendMailAsync(string receipient)
		{
			using var httpClient =
				clientFactory.CreateClient(
					ApplicationConstants.EmailServiceClient);

			var response =
				await httpClient.GetAsync(
					$"/email/send?recipient={receipient}");

			response.EnsureSuccessStatusCode();

			return true;
		}
	}
}
