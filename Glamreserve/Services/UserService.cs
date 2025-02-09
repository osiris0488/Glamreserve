using System.Linq;
using Glamreserve.Models;

namespace Glamreserve.Services
{
	public class UserService : IUserService
	{
		private readonly ApplicationDbContext _context;

		public UserService(ApplicationDbContext context)
		{
			_context = context;
		}

		public Usuario ValidateUser(string email, string password)
		{
			var user = _context.Usuarios.SingleOrDefault(u => u.Email == email);
			if (user == null || !VerifyPassword(password, user.PasswordHash))
			{
				return null;
			}
			return user;
		}

		private bool VerifyPassword(string password, string storedHash)
		{
			return BCrypt.Net.BCrypt.Verify(password, storedHash);
		}
	}
}