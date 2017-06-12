# RowDictionary

* Accepts any type as Key
* Accepts any type as Value
* Implements IEnumerable
* Allows access using [] operator
* When requesting a key if it isn't found throws an Exception
    - but you can use TryGetValue instead
* By default strings are compare Case Insensitive
    - but you can define you own comparer just implement IComparer and initialize RowDictionary wit it.
* Optimize Reads over Writes
	- Sorting when adding a new key and value, and
	- Using BinarySearch when Getting a new value

### Next Steps

* Add an example
* Implement IDictionary