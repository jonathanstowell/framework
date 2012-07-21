namespace ThreeBytes.Core.Facebook.Configuration.Abstract
{
    public interface IProvideFacebookConfiguration
    {
        string AppId { get; }
        string AppSecret { get; }
    }
}
