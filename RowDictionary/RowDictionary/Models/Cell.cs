namespace RowDictionary.Models
{
    public class Cell<TKey, TValue>
    {
        public Cell(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        public Cell(TKey key)
        {
            Key = key;
        }

        public TKey Key { get; }
        public TValue Value { get; }
    }
}