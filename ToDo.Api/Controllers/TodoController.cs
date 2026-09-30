using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using ToDo.Api.Extensions;
using ToDo.Application.Contracts;
using ToDo.Application.DTOs.Request;
using ToDo.Application.DTOs.Response;


namespace ToDo.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class TodoController : ControllerBase
	{
		private readonly ITodoService _todoService;
		private readonly ILogger<TodoController> logger;
		private readonly IDistributedCache distributedCache;
		private readonly IMemoryCache memoryCache;

		public TodoController(
			ITodoService todoService, ILogger<TodoController> logger, IDistributedCache distributedCache, IMemoryCache memoryCache)
		{
			this._todoService = todoService;
			this.logger = logger;
			this.distributedCache = distributedCache;
			this.memoryCache = memoryCache;
		}


		[HttpGet]
		public async Task<IActionResult> Get()
		{
			logger.LogInformation($"Executing GET method inside a TodoController at {DateTime.Now}");

			var cache = await distributedCache.GetStringAsync("todo");


			if (!string.IsNullOrEmpty(cache) && cache != "[]")
			{
				return Ok(JsonSerializer.Deserialize<List<TodoResponseDTO>>(cache));
			}

			var result = await _todoService.GetItems();

			if (result.IsFailure)
				return result.ToProblemDetails();

			var options = new DistributedCacheEntryOptions
			{
				AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
			};

			await distributedCache.SetStringAsync("todo", JsonSerializer.Serialize(result.Value), options);

			logger.LogInformation($"Execution of  GET method inside a TodoController completed at {DateTime.Now}");
			return Ok(result.Value);
		}


		[HttpPost]
		public async Task<IActionResult> Post(
			[FromBody] CreateTodoDTO todo)
		{
			logger.LogInformation("Executing POST method inside a TodoController at {0}", DateTime.Now);
			var result = await _todoService.CreateTodoAsync(todo);
			return result.IsSuccess ? Created() : result.ToProblemDetails();
		}
	}
}

