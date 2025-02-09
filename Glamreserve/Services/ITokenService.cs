namespace Glamreserve.Services
{
	public interface ITokenService
	{
		string GenerateToken(User user);
	}
}