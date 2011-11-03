namespace fd.Base.Common
{
    public interface ILocalData
    {
        int Count { get; }
        object this[object key] { get; set; }
        void Clear();
    }
}
