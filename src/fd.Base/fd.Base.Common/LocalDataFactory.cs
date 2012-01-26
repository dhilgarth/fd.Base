using System.Web;

namespace fd.Base.Common
{
    public class LocalDataFactory : ILocalDataFactory
    {
        public ILocalData Create()
        {
            if (HttpContext.Current != null)
                return new WebLocalData();
            return new DefaultLocalData();
        }
    }
}
