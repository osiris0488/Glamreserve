using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using Glamreserve.Pages.LoginRequest;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IConfiguration _config;

	public AuthController(IConfiguration config)
	{
		_config = config;
	}

	[HttpPost("login")]
	public IActionResult Login([FromBody] LoginRequest request)
	{
		var user = _userService.ValidateUser(request.Email, request.Password);
		if (user == null)
		{
			return Unauthorized(new { message = "Credenciales incorrectas" });
		};

		var token = _tokenService.GenerateToken(user);
		return Ok(new LoginResponse
		{
			Token = token,
			Nombre = user.Nombre,
			Email = user.Email,
			Rol = user.Rol
		});

	private string GenerateJwtToken(string username)
	{
		var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
		var claims = new[]
		{
			new Claim(ClaimTypes.Name, username)
		};

		var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
		var token = new JwtSecurityToken(
			_config["Jwt:Issuer"],
			_config["Jwt:Audience"],
			claims,
			expires: DateTime.UtcNow.AddHours(2),
			signingCredentials: credentials
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}


