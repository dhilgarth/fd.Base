using System;
using System.Collections;

namespace fd.Base.Common
{
    public class DefaultLocalData : ILocalData
    {
        [ThreadStatic] private static Hashtable _localData;

        private static Hashtable LocalHashtable
        {
            get
            {
                if (_localData == null)
                    _localData = new Hashtable();
                return _localData;
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
