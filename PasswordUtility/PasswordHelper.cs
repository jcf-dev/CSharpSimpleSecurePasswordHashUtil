using System;
using System.Security.Cryptography;

namespace PasswordUtility
{
    public static class PasswordHelper
    {
        public static int SaltSize { get; set; } = 256;
        public static int HashSize { get; set; } = 32;
        public static int Iterations { get; set; } = 1000;

        private static string Hash(string password, int iterations)
        {
            // Create Salt
            var salt = new byte[SaltSize];
            new RNGCryptoServiceProvider().GetBytes(salt);

            // Create Hash
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // Combine Salt and Hash
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Convert to Base64
            var base64Hash = Convert.ToBase64String(hashBytes);
            return base64Hash;
        }

        public static string Hash(string password)
        {
            return Hash(password, Iterations);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            // Get Hash Bytes
            var hashBytes = Convert.FromBase64String(hashedPassword);

            // Get Saved Salt
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Create Hash with Saved Salt 
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = pbkdf2.GetBytes(HashSize);

            // Get Result
            for (var i = 0; i < HashSize; i++)
                if (hashBytes[i + SaltSize] != hash[i])
                    return false;
            return true;
        }
    }
}
