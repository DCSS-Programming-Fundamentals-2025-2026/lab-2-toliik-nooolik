using System.Collections;

public class WordLengthComparer : IComparer
{
    public int Compare(object x, object y)
    {
        GameWord w1 = x as GameWord;
        GameWord w2 = y as GameWord;
        
        if (w1 != null && w2 != null)
        {
            return w1.Text.Length.CompareTo(w2.Text.Length);
        }
        return 0;
    }
}