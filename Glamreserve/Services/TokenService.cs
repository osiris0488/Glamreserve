using System.Collections.Generic;
using System.Text;
using System;

namespace Glamreserve.Services
{
	public class TokenService
	{
		private readonly IConfiguration _config;
		public TokenService(IConfiguration config)
		{
			_config = config;
		}
		public string GenerateToken(Usuario user)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Nombre),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(ClaimTypes.Role, user.Rol) // Se agrega el rol al token
			};
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.UtcNow.AddHours(2),
				signingCredentials: creds
			);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}
