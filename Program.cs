using lab_1_toliik_nooolik;
class Program
{
    static void Main()
    {
        WordProvider wordProvider = new WordProvider();

        GameSessionCollection history = new GameSessionCollection();

        bool wantToPlay = true;

        while (wantToPlay)
        {

            string secret = wordProvider.GetRandomWord();
            HangmanEngine game = new HangmanEngine(secret, 6);


            while (!game.IsGameOver())
            {
                GameInterface.Render(game);
                char guess = GameInterface.AskLetter();
                game.MakeGuess(guess);
            }

            GameInterface.Render(game);

            if (game.IsWon())
                Console.WriteLine("\n[Перемога!!!!!!] Красава!");
            else
                Console.WriteLine($"\n[Тебе повісили] Слово було: {game.GetSecretWord()}");

            int mistakes = 6 - game.CurrentLives;
            history.Add(new GameSession(secret, game.IsWon(), mistakes));


            Console.WriteLine("\nЩе раз?  (y/n)");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y" && choice != "n")
            {
                wantToPlay = false;
            }
        }

        Console.WriteLine("\n=== СТАТИСТИКА ІГОР (відсортовано за помилками) ===");
        
        history.Sort(); 

        IEnumerator it = history.GetEnumerator();
        
        while (it.MoveNext())
        {
            GameSession s = (GameSession)it.Current;
            string status = s.IsWon ? "Виграв" : "Програв";
            Console.WriteLine($"Слово: {s.Word} | Помилок: {s.Mistakes} | Статус: {status}");
        }

        Console.WriteLine("Бувай");
    }
}
// Done.