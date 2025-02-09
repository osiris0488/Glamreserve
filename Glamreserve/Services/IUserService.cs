namespace Glamreserve.Services
{
	public interface IUserService
	{
		Usuario ValidateUser(string email, string password);
	}
}