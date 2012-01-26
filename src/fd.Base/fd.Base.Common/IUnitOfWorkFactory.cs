namespace fd.Base.Common
{
    public interface IUnitOfWorkFactory
    {
        void DisposeUnitOfWork(IUnitOfWork unitOfWork);
        IUnitOfWork Start();
    }
}
