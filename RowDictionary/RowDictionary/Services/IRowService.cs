using System.Collections.Generic;
using System.Linq;

namespace RowDictionary.Services
{
    public interface IRowService<TKey, TValue>
    {
        void Add(List<KeyValuePair<TKey, TValue>> row, TKey key, TValue value);
        TValue Get(List<KeyValuePair<TKey, TValue>> row, IEqualityComparer<TKey> equalityComparer, TKey key);
        bool TryGetValue(List<KeyValuePair<TKey, TValue>> row, IEqualityComparer<TKey> equalityComparer, TKey key, out TValue value);
    }

    public class RowService<TKey, TValue> : IRowService<TKey, TValue>
    {
        public void Add(List<KeyValuePair<TKey, TValue>> row, TKey key, TValue value)
        {
            row.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool TryGetValue(List<KeyValuePair<TKey, TValue>> row, IEqualityComparer<TKey> equalityComparer, TKey key, out TValue value)
        {
            value = default(TValue);
            if (!row.Any(x => equalityComparer.Equals(x.Key, key))) return false;
            value = row.First(x => equalityComparer.Equals(x.Key, key)).Value;
            return true;
        }

        public TValue Get(List<KeyValuePair<TKey, TValue>> row, IEqualityComparer<TKey> equalityComparer, TKey key)
        {
            TValue result;
            if (TryGetValue(row, equalityComparer, key, out result)) return result;
            throw new KeyNotFoundException();
        }
    }
}
