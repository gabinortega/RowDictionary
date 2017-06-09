using System.Collections.Generic;
using System.Linq;

namespace RowDictionary
{
    public class RowDictionary<TKey, TValue>
    {
        public List<KeyValuePair<TKey, TValue>> Row { get; set; }

        public RowDictionary()
        {
            Row = new List<KeyValuePair<TKey, TValue>>();
        }

        public void Add(TKey key, TValue value)
        {
            Row.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            if (!Row.Any(x => x.Key.Equals(key))) return false;
            value = Row.FirstOrDefault(x => x.Key.Equals(key)).Value;
            return true;
        }
    }
}
