using System;

public class GameWord : IComparable
{
    public string Text { get; set; }
    public string Hint { get; set; }

    public GameWord(string text, string hint)
    {
        Text = text;
        Hint = hint;
    }

    public int CompareTo(object obj)
    {
        if (obj == null) 
        {
            return 1;
        }    
        GameWord other = obj as GameWord;
        if (other != null)
        {
            return string.Compare(this.Text, other.Text, StringComparison.OrdinalIgnoreCase);
        }
        throw new ArgumentException("Provided object is not a GameWord instance");
    }
}