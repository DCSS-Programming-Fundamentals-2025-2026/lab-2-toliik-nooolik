using System;
using System.Collections;

public class GameWordCollection : IEnumerable
{
    private GameWord[] _items;
    private int _count;

    public GameWordCollection(int capacity)
    {
        _items = new GameWord[capacity];
        _count = 0;
    }

    public int Count 
    { 
        get { return _count; } 
    }

    public void Add(GameWord item)
    {
        if (_count < _items.Length)
        {
            _items[_count] = item;
            _count++; 
        }
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count) 
        {
            return;
        }

        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }
        
        _items[_count - 1] = null;
        _count--;
    }

    public GameWord GetAt(int index) 
    {
        return _items[index];
    }

    public void SetAt(int index, GameWord item) 
    {
        _items[index] = item;
    }

    public IEnumerator GetEnumerator()
    {
        return new GameWordEnumerator(_items, _count);
    }

    public void Sort(IComparer comparer = null)
    {
        for (int i = 0; i < _count - 1; i++)
        {
            for (int j = 0; j < _count - i - 1; j++)
            {
                bool swap = false;
                if (comparer == null)
                {
                    // Використовуємо IComparable моделі
                    if (_items[j].CompareTo(_items[j + 1]) > 0) swap = true;
                }
                else
                {
                    // Використовуємо зовнішній IComparer
                    if (comparer.Compare(_items[j], _items[j + 1]) > 0) swap = true;
                }

                if (swap)
                {
                    var temp = _items[j];
                    _items[j] = _items[j + 1];
                    _items[j + 1] = temp;
                }
            }
        }
    }
}