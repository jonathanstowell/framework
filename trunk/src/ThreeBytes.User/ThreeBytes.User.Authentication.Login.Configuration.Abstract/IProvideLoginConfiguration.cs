namespace ThreeBytes.User.Authentication.Login.Configuration.Abstract
{
    public interface IProvideLoginConfiguration
    {
        int LockUserOutAfterNAttempts { get; }
    }
}
