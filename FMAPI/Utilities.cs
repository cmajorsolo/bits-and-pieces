//The Utilities class contains a Encode function that can encode a string by SHA1.
//When a user trying to log in, his typed in password will be encoded with SHA1 first. Then the encoded password
// is used to compare the password saved in DB. 
public class Utilities
{
	public static string Encode(string value)
	{ 
		var SHA1Encoder = System.Security.Cryptography.SHA1.Create();
		return BitConverter.ToString(SHA1Encoder.ComputeHash(new System.Text.ASCIIEncoding().GetBytes(value ?? ""))).ToLower().Replace("-", "");
	}

}