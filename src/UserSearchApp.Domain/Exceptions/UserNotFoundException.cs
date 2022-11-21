
namespace UserSearchApp.Services.Exceptions;

public class UserNotFoundException : Exception
{
	public UserNotFoundException() : base("User was not found")
	{
	}
}