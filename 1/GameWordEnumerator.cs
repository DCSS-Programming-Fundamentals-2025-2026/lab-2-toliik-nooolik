using System.Collections;

public class GameWordEnumerator : IEnumerator
{
    private GameWord[] _items;
    private int _count;
    private int _position = -1;

    public GameWordEnumerator(GameWord[] items, int count)
    {
        _items = items;
        _count = count;
    }

    public bool MoveNext()
    {
        _position++;
        return (_position < _count);
    }

        public object Current
    {
        get
        {
            return _items[_position];
        }
    }

    public void Reset()
    {
        _position = -1;
    }
}