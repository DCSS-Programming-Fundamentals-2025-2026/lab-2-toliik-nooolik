using System;

namespace lab_1_toliik_nooolik
{
    public class GameSession : IComparable
    {
        public string Word { get; set; }     
        public bool IsWon { get; set; }     
        public int Mistakes { get; set; }    

        public GameSession(string word, bool isWon, int mistakes)
        {
            Word = word;
            IsWon = isWon;
            Mistakes = mistakes;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) 
            {
                return 1;
            }
            GameSession other = obj as GameSession;

            if (other != null)
            {
                return this.Mistakes.CompareTo(other.Mistakes);
            }
            else
            {
                throw new ArgumentException("Об'єкт не є GameSession");
            }
        }
    }
}