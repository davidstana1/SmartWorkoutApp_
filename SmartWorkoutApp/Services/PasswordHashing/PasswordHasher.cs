using System.Security.Cryptography;
using System.Text;

namespace SmartWorkoutApp.Services.PasswordHashing;

public static class PasswordHasher
{
    public static string HashPassword(string password, string salt)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Concatenate password and salt
            string combined = password + salt;

            // Compute hash
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combined));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }

    public static string GenerateSalt()
    {
        byte[] salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }
}