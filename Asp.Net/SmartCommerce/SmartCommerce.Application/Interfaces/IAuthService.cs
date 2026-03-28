using System;
using System.Collections.Generic;
using System.Text;
using SmartCommerce.Application.DTOs;

namespace SmartCommerce.Application.Interfaces
{
	public interface IAuthService
	{
		Task<string> RegisterAsync(RegisterDto dto);
		Task<string> LoginAsync(LoginDto dto);
	}
}
