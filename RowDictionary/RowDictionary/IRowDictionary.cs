using System.Collections;

namespace RowDictionary
{
    public interface IRowDictionary<TKey, TValue>
    {
        TValue this[TKey key] { get; set; }

        void Add(TKey key, TValue value);
        TValue Get(TKey key);
        IEnumerator GetEnumerator();
        bool TryGetValue(TKey key, out TValue value);
    }
}