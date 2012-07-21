namespace ThreeBytes.Core.Twitter.Configuration.Abstract
{
    public interface IProvideTwitterConfiguration
    {
        string ConsumerKey { get; }
        string ConsumerSecret { get; }
    }
}
