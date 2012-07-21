namespace ThreeBytes.Core.Security.Encryption.Abstract
{
    public interface IPasswordEncoder
    {
        string EncodePassword(string password);
    }
}
