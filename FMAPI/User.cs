// This class is the User model. A User has two string properties, UserName and Password
public class User
{
	[Key]
	public string UserID { get; set; }

	[Required]
	[Display(Name="User Name")]
	[MaxLength(100)]
	public string UserName { get; set; }

	[Required]
	[DataType(DataType.Password)]
	[Display(Name = "Password")]
	[MaxLength(100)]
	public string Password { get; set; }

	[Display(Name = "Remember Me")]
	public bool RememberMe { get; set; }

	//This is the function to verify if the user is the right one.
	public bool Authenticate(string userName, string password)
	{
		using (var context = new UserDb())
		{
			//Compare the encoded type-in password with the encoded password in DB.
			var user = from u in context.Users where (u.UserName == UserName) && (u.Password == Utilities.Encode(password)) select u;
			//If the user exists in DB, return true
			if (user != null)
			{
				return true;
			}
			else
				return false;

		}
	}
}