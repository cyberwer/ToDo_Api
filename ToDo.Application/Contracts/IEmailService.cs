namespace ToDo.Application.Contracts
{
	public interface IEmailService
	{
		Task<bool> SendMailAsync(string recipient);
	}

	



}
