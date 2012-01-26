using System.Collections;
using System.Web;

namespace fd.Base.Common
{
    public class WebLocalData : ILocalData
    {
        private static readonly object LocalDataHashtableKey = new object();

        public int Count
        {
            get { return LocalHashtable.Count; }
        }

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

        public object this[object key]
        {
            get { return LocalHashtable[key]; }
            set { LocalHashtable[key] = value; }
        }

        public void Clear()
        {
            LocalHashtable.Clear();
        }
    }
}
