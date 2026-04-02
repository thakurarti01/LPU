using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
	public class User
	{
		public int UserId { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string Role { get; set; } // Customer, Owner, Admin
		public bool IsVerified { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
