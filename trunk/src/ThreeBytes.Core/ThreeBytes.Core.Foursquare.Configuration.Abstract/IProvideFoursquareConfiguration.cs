namespace ThreeBytes.Core.Foursquare.Configuration.Abstract
{
    public interface IProvideFoursquareConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
    }
}
