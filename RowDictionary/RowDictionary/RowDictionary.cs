using System.Collections;
using System.Collections.Generic;
using RowDictionary.Services;

namespace RowDictionary
{
    public class RowDictionary<TKey, TValue> : IEnumerable
    {
        private readonly IEqualityComparer<TKey> _equalityService;
        private readonly IRowService<TKey, TValue> _rowService;
        public List<KeyValuePair<TKey, TValue>> Row { get; set; }

        public RowDictionary(IEqualityComparer<TKey> comparer)
        {
            Row = new List<KeyValuePair<TKey, TValue>>();
            _rowService = new RowService<TKey, TValue>();
            _equalityService = new EqualityServiceProvider<TKey>().GetEqualityService(comparer);
        }

        public RowDictionary() : this(EqualityComparer<TKey>.Default)
        {
        }

        public TValue this[TKey key]
        {
            get
            {
                return _rowService.Get(Row, _equalityService, key);
            }
            set
            {
                Add(key, value);
            }
        }

        public void Add(TKey key, TValue value)
        {
            _rowService.Add(Row, key, value);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _rowService.TryGetValue(Row, _equalityService, key, out value);
        }

        public IEnumerator GetEnumerator()
        {
            return Row.GetEnumerator();
        }
    }
}
