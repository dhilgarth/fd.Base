using System;
using System.Collections;

namespace fd.Base.Common
{
    public class DefaultLocalData : ILocalData
    {
        [ThreadStatic]
        private static Hashtable _localData;

        public int Count
        {
            get { return LocalHashtable.Count; }
        }

        private static Hashtable LocalHashtable
        {
            get
            {
                if (_localData == null)
                    _localData = new Hashtable();
                return _localData;
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
