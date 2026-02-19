using System.Collections; 

namespace lab_1_toliik_nooolik
{
    public class WordLengthComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            GameSession s1 = x as GameSession;
            GameSession s2 = y as GameSession;

            if (s1 != null && s2 != null)
            {
                return s1.Word.Length.CompareTo(s2.Word.Length);
            }
            
            return 0;
        }
    }
}