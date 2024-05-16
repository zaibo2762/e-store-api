namespace e_store.Hasher
{
    using Microsoft.AspNetCore.Cryptography.KeyDerivation;
    using System;
    using System.Security.Cryptography;
    using System.Text;
    public class PasswordHasher
    {
        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));

            return $"{Convert.ToBase64String(salt)}.{hashedPassword}";
        }

        public bool VerifyPassword(string storedPassword, string providedPassword)
        {
            var parts = storedPassword.Split('.');
            var salt = Convert.FromBase64String(parts[0]);
            var hashedPassword = parts[1];

            string hashedProvidedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: providedPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));

            return hashedPassword == hashedProvidedPassword;
        }
    }
}
