using System;

namespace fd.Base.Common
{
    /// <summary>Holds extension methods for <see cref="IUnitOfWork" /> and <see cref="IUnitOfWorkFactory" /> .</summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// Executes the specified <see langword="delegate"/> on a new unit of work that is obtained from the <paramref name="unitOfWorkFactory" /> .
        /// </summary>
        /// <typeparam name="TReturn">The return type of the delegate.</typeparam>
        /// <param name="unitOfWorkFactory">The unit of work factory.</param>
        /// <param name="func">The <see langword="delegate"/> to be executed.</param>
        /// <returns>The result of the delegate.</returns>
        public static TReturn WithRepository<TReturn>(this IUnitOfWorkFactory unitOfWorkFactory, Func<IRepository, TReturn> func)
        {
            using (var unitOfWork = unitOfWorkFactory.Start())
            {
                return func(unitOfWork.Repository);
            }
        }
    }
}
