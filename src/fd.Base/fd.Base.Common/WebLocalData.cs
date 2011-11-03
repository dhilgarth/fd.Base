using System.Collections;
using System.Web;

namespace fd.Base.Common
{
    public class WebLocalData : ILocalData
    {
        private static readonly object LocalDataHashtableKey = new object();

        private static Hashtable LocalHashtable
        {
            get
            {
                var webHashtable = HttpContext.Current.Items[LocalDataHashtableKey] as Hashtable;
                if (webHashtable == null)
                {
                    webHashtable = new Hashtable();
                    HttpContext.Current.Items[LocalDataHashtableKey] = webHashtable;
                }
                return webHashtable;
            }
        }

        #region ILocalData Members

        public object this[object key]
        {
            get { return LocalHashtable[key]; }
            set { LocalHashtable[key] = value; }
        }

        public int Count
        {
            get { return LocalHashtable.Count; }
        }

        public void Clear()
        {
            LocalHashtable.Clear();
        }

        #endregion
    }
}
