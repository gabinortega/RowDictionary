using System;
using System.Collections.Generic;

namespace RowDictionary.Services
{
    public interface IEqualityServiceProvider<TKey>
    {
        IComparer<TKey> GetKeyComparer(IComparer<TKey> comparer);
    }

    public class EqualityServiceProvider<TKey> : IEqualityServiceProvider<TKey>
    {
        public IComparer<TKey> GetKeyComparer(IComparer<TKey> comparer)
        {
            if (typeof(TKey) == typeof(string)) comparer = (IComparer<TKey>)StringComparer.InvariantCultureIgnoreCase;
            return comparer;
        }
    }
}