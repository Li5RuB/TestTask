namespace TestTask.Services.Hasher
{
    public interface IPasswordHasher
    {
        public string Hash(string password);

        public bool VerifyHashedPassword(string hashedPassword, string password);
    }
}