using System.Web;

namespace fd.Base.Common
{
    public class LocalDataFactory : ILocalDataFactory
    {
        #region ILocalDataFactory Members

        public ILocalData Create()
        {
            if (HttpContext.Current != null)
                return new WebLocalData();
            return new DefaultLocalData();
        }

        #endregion
    }
}
