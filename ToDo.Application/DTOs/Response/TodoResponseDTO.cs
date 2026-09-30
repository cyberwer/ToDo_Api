namespace ToDo.Application.DTOs.Response
{
	public record TodoResponseDTO(
	   string Name,
	   string Description,
	   List<TodoMetadata>? Metadata
   );

	public record TodoMetadata(
		string Title,
		string Description,
		string Priority,
		string Status,
		DateTime? DueDate
	);
}
