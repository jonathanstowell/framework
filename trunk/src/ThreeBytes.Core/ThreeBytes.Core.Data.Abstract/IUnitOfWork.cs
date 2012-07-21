using System;
using System.Data;

namespace ThreeBytes.Core.Data.Abstract
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets a value indicating whether this instance is in transaction.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is in transaction; otherwise, <c>false</c>.
        /// </value>
        bool IsInTransaction { get; }

        /// <summary>
        /// Begins the transaction.
        /// </summary>
        void BeginTransaction();
        void BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Rolls the back transaction.
        /// </summary>
        void RollBackTransaction();

        /// <summary>
        /// Commits the transaction.
        /// </summary>
        /// <exception cref="ApplicationException">Cannot roll back a transaction while there is no transaction running.</exception>
        bool CommitTransaction();
    }
}
