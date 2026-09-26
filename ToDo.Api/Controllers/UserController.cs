using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Requests;

namespace ToDo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController(IUserService userService) : ControllerBase
	{
		//private readonly IUserService userService;
		//public UserController()
		//{
		//	this.userService = userService;
		//}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] CreateUserDTO request)
		{
			var response = await userService.CreateUserAsync(request);
			return Created(); //201
		}

	}
}
