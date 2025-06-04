using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
    public static string GenerateSalt()
    {
        var rng = new RNGCryptoServiceProvider();
        byte[] saltBytes = new byte[16];
        rng.GetBytes(saltBytes);
        return Convert.ToBase64String(saltBytes);
    }

    public static string HashPassword(string password, string salt)


    {
        using (var sha = SHA256.Create())
        {
            var combined = Encoding.UTF8.GetBytes(password + salt);
            return Convert.ToBase64String(sha.ComputeHash(combined));
        }
    }
}
