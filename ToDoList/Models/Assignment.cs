using System;
namespace ToDoList.Models
{
	public class Assignment
	{
		public Guid Id { get; set; }
		public string? Description { get; set; }
		public bool IsCompleted { get; set; }

	}
}

