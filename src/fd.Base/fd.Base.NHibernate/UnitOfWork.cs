using System;
using fd.Base.Common;
using NHibernate;

namespace fd.Base.NHibernate
{
    /// <summary>The unit of work.</summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IRepository _repository;
        private readonly ISession _session;
        private readonly ITransaction _transaction;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        private bool _isDisposed;

        /// <summary>Initializes a new instance of the <see cref="UnitOfWork" /> class.</summary>
        /// <param name="unitOfWorkFactory">The unit of work factory.</param>
        /// <param name="session">The session.</param>
        public UnitOfWork(IUnitOfWorkFactory unitOfWorkFactory, ISession session)
        {
            if (unitOfWorkFactory == null)
                throw new ArgumentNullException("unitOfWorkFactory");
            if (session == null)
                throw new ArgumentNullException("session");
            _unitOfWorkFactory = unitOfWorkFactory;
            _repository = new Repository(session);
            _session = session;
            _transaction = session.BeginTransaction();
        }

        /// <summary>Gets the repository.</summary>
        public IRepository Repository
        {
            get
            {
                CheckNotDisposed();
                return _repository;
            }
        }

        /// <summary>Commits this instance.</summary>
        public void Commit()
        {
            CheckNotDisposed();
            _transaction.Commit();
        }

        /// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
        public void Dispose()
        {
            if (_isDisposed)
                return;

            if (_transaction.IsActive)
                Rollback();

            _transaction.Dispose();
            _session.Dispose();
            _isDisposed = true;
            _unitOfWorkFactory.DisposeUnitOfWork(this);
        }

        /// <summary>Rolls back this instance.</summary>
        public void Rollback()
        {
            CheckNotDisposed();
            _transaction.Rollback();
        }

        /// <summary>Checks that this instance is not disposed.</summary>
        private void CheckNotDisposed()
        {
            if (_isDisposed)
                throw new ObjectDisposedException("UnitOfWork");
        }
    }
}
