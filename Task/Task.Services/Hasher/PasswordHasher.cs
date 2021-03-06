using System;
using System.Security.Cryptography;
using TestTask.Services.Models;

namespace TestTask.Services.Hasher
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private readonly int saltSize;
        private readonly int hashSize;
        private readonly int iterations;
        public PasswordHasher(IHashSettings settings)
        {
            saltSize = settings.SaltSize;
            hashSize = settings.HashSize;
            iterations = settings.Iterations;
        }

        public string Hash(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, saltSize, iterations))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(hashSize);
            }

            byte[] dst = new byte[saltSize + hashSize + 0x01];
            Buffer.BlockCopy(salt, 0, dst, 1, saltSize);
            Buffer.BlockCopy(buffer2, 0, dst, saltSize + 0x01, hashSize);
            return Convert.ToBase64String(dst);
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }

            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != (saltSize + hashSize + 0x01)) || (src[0] != 0))
            {
                return false;
            }

            byte[] dst = new byte[saltSize];
            Buffer.BlockCopy(src, 1, dst, 0, saltSize);
            byte[] buffer3 = new byte[hashSize];
            Buffer.BlockCopy(src, saltSize + 0x01, buffer3, 0, hashSize);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, iterations))
            {
                buffer4 = bytes.GetBytes(hashSize);
            }

            return ByteArraysEqual(buffer3, buffer4);
        }
        
        private static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }
    }
}