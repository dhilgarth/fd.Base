using System;
using fd.Base.Common;
using NHibernate;

namespace fd.Base.NHibernate
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly string _currentUnitOfWorkKey;
        private readonly ILocalData _localData;
        private readonly ISessionFactory _sessionFactory;

        public UnitOfWorkFactory(ISessionFactory sessionFactory, ILocalData localData)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");
            if (localData == null)
                throw new ArgumentNullException("localData");
            _currentUnitOfWorkKey = "CurrentUnitOfWork.Key\\" + Guid.NewGuid().ToString("N");
            _sessionFactory = sessionFactory;
            _localData = localData;
        }

        private IUnitOfWork CurrentUnitOfWork
        {
            get { return _localData[_currentUnitOfWorkKey] as IUnitOfWork; }
            set { _localData[_currentUnitOfWorkKey] = value; }
        }

        public void DisposeUnitOfWork(IUnitOfWork unitOfWork)
        {
            unitOfWork.Dispose();
            CurrentUnitOfWork = null;
        }

        public IUnitOfWork Start()
        {
            if (CurrentUnitOfWork != null)
                throw new InvalidOperationException("You cannot start more than one unit of work at the same time.");
            var unitOfWork = new UnitOfWork(this, _sessionFactory.OpenSession());
            CurrentUnitOfWork = unitOfWork;
            return unitOfWork;
        }
    }
}
