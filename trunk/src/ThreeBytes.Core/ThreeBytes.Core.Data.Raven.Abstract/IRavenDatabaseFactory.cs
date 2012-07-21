using System;
using Raven.Client;

namespace ThreeBytes.Core.Data.Raven.Abstract
{
    public interface IRavenDatabaseFactory : IDisposable
    {
        IDocumentStore DocumentStore { get; }
        IDocumentSession Session { get; }
    }
}
