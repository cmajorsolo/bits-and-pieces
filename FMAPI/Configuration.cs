// This is the Configuration class with a seed method. 
// A default user generated in the seed method for testing. 
internal sealed class Configuration : DbMigrationsConfiguration<FMAPI091701.Models.UserDb>
{
	public Configuration()
	{
		AutomaticMigrationsEnabled = false;
	}

	protected override void Seed(FMAPI091701.Models.UserDb context)
	{
		context.Users.AddOrUpdate(x => x.UserID, new User()
		{
			UserID = "1",
			UserName = "Huali",
			Password = "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3",
			RememberMe = true
		});
	}
}