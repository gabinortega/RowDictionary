using System;
using System.Collections.Generic;

namespace RowDictionary.Services
{
    public interface IEqualityServiceProvider<T>
    {
        IEqualityComparer<T> GetEqualityComparer(IEqualityComparer<T> equalityComparer);
    }

    public class EqualityServiceProvider<T>
    {
        public IEqualityComparer<T> GetEqualityService(IEqualityComparer<T> equalityComparer)
        {
            if (typeof(T) != typeof(string)) return equalityComparer;
            return (IEqualityComparer<T>)StringComparer.InvariantCultureIgnoreCase;
        }
    }
}
