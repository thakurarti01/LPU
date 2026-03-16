namespace ProjectManagementSystem.DTOs
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
	}

	public class CreateCategoryDto
	{
		public string Name { get; set; } = string.Empty;
		public int DisplayOrder { get; set; }
	}

	public class UpdateCategoryDto
	{
		public string? Name { get; set; }
		public int? DisplayOrder { get; set; }
	}
}