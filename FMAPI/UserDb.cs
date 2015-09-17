//This is the DB context. Using it to get User from database. 
public class UserDb:DbContext
{
	public DbSet<User> Users { get; set; }
}