using System;

namespace fd.Base.Common
{
    /// <summary>
    /// Represents a unit of work in the context of a data store.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the repository.
        /// </summary>
        IRepository Repository { get; }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rolls back this instance.
        /// </summary>
        void Rollback();
    }
}
