namespace fd.Base.Common
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Start();
        void DisposeUnitOfWork(IUnitOfWork unitOfWork);
    }
}
