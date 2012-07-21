namespace ThreeBytes.Core.Upload.Configuration.Abstract
{
    public interface IDiskFileStoreConfiguration
    {
        string Directory { get; }
        string TemporaryDirectory { get; }
    }
}
