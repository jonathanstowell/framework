namespace ThreeBytes.User.Authentication.OAuth.Configuration.Abstract
{
    public interface IProvideOAuthFoursquareConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
