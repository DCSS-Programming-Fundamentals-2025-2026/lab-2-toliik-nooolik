namespace lab_1_toliik_nooolik
{
public class HangmanEngine
{
    private string _targetWord;
    private bool[] _revealed;
    public int CurrentLives { get; private set; }
    public int MaxLives { get; private set; }

    public HangmanEngine(string word, int lives)
    {
        _targetWord = word.ToLower();
        _revealed = new bool[_targetWord.Length];
        MaxLives = lives;
        CurrentLives = lives;
    }

    public bool MakeGuess(char letter)
    {
        letter = char.ToLower(letter);
        bool hit = false;

        for (int i = 0; i < _targetWord.Length; i++)
        {
            if (_targetWord[i] == letter && !_revealed[i])
            {
                _revealed[i] = true;
                hit = true;
            }
        }

        if (!hit)
        {
            CurrentLives--;
        }

        return hit;
    }

    public string GetDisplayWord()
    {
        char[] display = new char[_targetWord.Length];
        for (int i = 0; i < _targetWord.Length; i++)
        {
            display[i] = _revealed[i] ? _targetWord[i] : '_';
        }
        return new string(display);
    }

    public bool IsWon()
    {
        for (int i = 0; i < _revealed.Length; i++)
        {
            if (!_revealed[i]) return false;
        }
        return true;
    }

    public bool IsGameOver() => CurrentLives <= 0 || IsWon();
    public string GetSecretWord() => _targetWord;
}
}