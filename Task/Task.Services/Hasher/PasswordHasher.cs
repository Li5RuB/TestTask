using System;
using System.Security.Cryptography;

namespace TestTask.Services.Hasher
{
    public sealed class PasswordHasher : IPasswordHasher
    {
        private const int SaltSize = 0x10;
        private const int HashSize = 0x20;
        private const int Iterations = 0x3e8;

        public string Hash(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                throw new ArgumentNullException(nameof(password));
            }

            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, SaltSize, Iterations))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(HashSize);
            }

            byte[] dst = new byte[SaltSize + HashSize + 0x01];
            Buffer.BlockCopy(salt, 0, dst, 1, SaltSize);
            Buffer.BlockCopy(buffer2, 0, dst, SaltSize + 0x01, HashSize);
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
            if ((src.Length != (SaltSize + HashSize + 0x01)) || (src[0] != 0))
            {
                return false;
            }

            byte[] dst = new byte[SaltSize];
            Buffer.BlockCopy(src, 1, dst, 0, SaltSize);
            byte[] buffer3 = new byte[HashSize];
            Buffer.BlockCopy(src, SaltSize + 0x01, buffer3, 0, HashSize);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, Iterations))
            {
                buffer4 = bytes.GetBytes(HashSize);
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