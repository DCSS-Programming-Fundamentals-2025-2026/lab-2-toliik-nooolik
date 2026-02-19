using System;
using System.Collections;

namespace lab_1_toliik_nooolik
{
    public class GameSessionCollection : IEnumerable
    {
        private GameSession[] _items; 
        private int _count;          

        public GameSessionCollection(int capacity = 10)
        {
            _items = new GameSession[capacity];
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Add(GameSession item)
        {
            if (_count == _items.Length)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
            _items[_count] = item;
            _count = _count + 1;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count = _count - 1;
            _items[_count] = null; 
        }

        public GameSession GetAt(int index)
        {
            return _items[index];
        }

        public IEnumerator GetEnumerator()
        {
            return new GameSessionEnumerator(_items, _count);
        }

        private class GameSessionEnumerator : IEnumerator
        {
            private GameSession[] _items;
            private int _count;
            private int _position = -1; 

            public GameSessionEnumerator(GameSession[] items, int count)
            {
                _items = items;
                _count = count;
            }

            public bool MoveNext()
            {
                _position++;
                return (_position < _count);
            }

            public void Reset()
            {
                _position = -1;
            }

            public object Current
            {
                get
                {
                    if (_position < 0 || _position >= _count)
                    {
                        throw new InvalidOperationException();
                    }
                    return _items[_position];
                }
            }
        }

        public void Sort()
        {
            Array.Sort(_items, 0, _count);
        }
    }
}