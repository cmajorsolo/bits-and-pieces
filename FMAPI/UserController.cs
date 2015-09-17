// UserController class contains the Login method working behind the screen. 
public class UserController : Controller
{
	[HttpPost]
	public ActionResult Login(Models.User user)
	{
		if (ModelState.IsValid)
		{
			if (user.Authenticate(user.UserName, user.Password))
			{
				//If user is authenticated, send a cookie contains user info.
				FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
				return RedirectToAction("Index", "Home");
			}
			else
			{
				//If the user cannot be verified, add a model error
				ModelState.AddModelError("", "User not valid");
			}
		}
		return View(user);
	}
}