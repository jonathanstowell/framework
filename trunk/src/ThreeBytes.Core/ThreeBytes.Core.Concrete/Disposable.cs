using System;

namespace ThreeBytes.Core.Concrete
{
    /// <summary>
    /// Releases unmanaged resources and performs other cleanup operations before the
    /// child class is reclaimed by garbage collection.
    /// </summary>
    public class Disposable : IDisposable
    {
        /// <summary>
        /// Has the class been disposed.
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="Disposable"/> is reclaimed by garbage collection.
        /// </summary>
        ~Disposable()
        {
            dispose(false);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        private void dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
        }

        /// <summary>
        /// Disposes the core.
        /// </summary>
        protected virtual void DisposeCore()
        {
        }
    }
}
