// This is User class.
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

  //Authentication method
	public bool Authenticate(string userName, string password)
	{
		using (var context = new UserDb())
		{
			//Get the user from DB if the password in DB equals encoded user-type-in password
			var user = from u in context.Users where (u.UserName == UserName) && (u.Password == Utilities.Encode(password)) select u;
			if (user != null)
			{
				return true;
			}
			else
				return false;

		}
	}
}

//This is the database context class. 
public class UserDb:DbContext
{
	public DbSet<User> Users { get; set; }
}

//Utilities class contains the encoding function
public class Utilities
{
	public static string Encode(string value)
	{ 
		var SHA1Encoder = System.Security.Cryptography.SHA1.Create();
		return BitConverter.ToString(SHA1Encoder.ComputeHash(new System.Text.ASCIIEncoding().GetBytes(value ?? ""))).ToLower().Replace("-", "");
	}
}

//The login page controller
//System.Web.Security is used.
public class LoginController : Controller
{
	[HttpPost]
	public ActionResult Login(Models.User user)
	{
		if (ModelState.IsValid)
		{
			if (user.Authenticate(user.UserName, user.Password))
			{
				//Set the authentication mark
				FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ModelState.AddModelError("", "User not valid");
			}
		}
		return View(user);
	}
}

//To tell if a user is authenticated already in subseqential call, use Request.IsAuthenticated in cshtml. 