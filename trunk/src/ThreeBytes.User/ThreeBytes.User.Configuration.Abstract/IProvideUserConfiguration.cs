namespace ThreeBytes.User.Configuration.Abstract
{
    public interface IProvideUserConfiguration
    {
        string ApplicationName { get; }
        string RedirectController { get; }
        string RedirectAction { get; }
        int MinimumPasswordLength { get; }
        int MaximumPasswordLength { get; }
        int MinimumUsernameLength { get; }
        int MaximumUsernameLength { get; }
    }
}
