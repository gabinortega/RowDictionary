using System.Collections.Generic;
using RowDictionary.Models;

namespace RowDictionary.Services
{
    public class CellComparer<TKey,TValue> : IComparer<Cell<TKey, TValue>>
    {
        private readonly IComparer<TKey> _equalityService;

        public CellComparer(IComparer<TKey> equalityService)
        {
            _equalityService = equalityService;
        }

        public int Compare(Cell<TKey, TValue> cell01, Cell<TKey, TValue> cell02)
        {
            if (cell01 == null || cell01.Key == null) return -1;

            return cell02 == null || cell02.Key == null
                ? 1
                : _equalityService.Compare(cell01.Key, cell02.Key);
        }
    }
}