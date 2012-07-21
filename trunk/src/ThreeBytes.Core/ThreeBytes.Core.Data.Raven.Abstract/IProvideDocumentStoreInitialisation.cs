using Raven.Client;

namespace ThreeBytes.Core.Data.Raven.Abstract
{
    public interface IProvideDocumentStoreInitialisation
    {
        IDocumentStore DocumentStore { get; }
    }
}
