using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RowDictionary.Models;
using RowDictionary.Services;

namespace RowDictionary
{
    public class RowDictionary<TKey, TValue> : IEnumerable, IRowDictionary<TKey, TValue>
    {
        private List<Cell<TKey, TValue>> _row;
        private readonly IComparer<Cell<TKey, TValue>> _equalityService;

        public RowDictionary(IComparer<TKey> keyComparer, IEqualityServiceProvider<TKey> equalityServiceProvider)
        {
            keyComparer = equalityServiceProvider.GetKeyComparer(keyComparer);
            _equalityService = new CellComparer<TKey, TValue>(keyComparer);
            _row = new List<Cell<TKey, TValue>>();
        }

        public RowDictionary(IComparer<TKey> keyComparer) : this(keyComparer, new EqualityServiceProvider<TKey>())
        {
        }

        public RowDictionary() : this(Comparer<TKey>.Default, new EqualityServiceProvider<TKey>())
        {
        }

        public IEnumerator GetEnumerator()
        {
            return _row.GetEnumerator();
        }

        public TValue this[TKey key]
        {
            get { return Get(key); }
            set { Add(key, value); }
        }

        public void Add(TKey key, TValue value)
        {
            _row.Add(new Cell<TKey, TValue>(key, value));
            Sort();
        }

        private void Sort()
        {
            _row = _row.OrderBy(x => x, _equalityService).ToList();
        }

        public TValue Get(TKey key)
        {
            TValue result;
            if (TryGetValue(key, out result)) return result;
            throw new KeyNotFoundException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            var cellToFind = new Cell<TKey, TValue>(key);
            var cellIndex = _row.BinarySearch(cellToFind, _equalityService);
            if (cellIndex < 0) return false;
            value = _row[cellIndex].Value;
            return true;
        }
    }
}