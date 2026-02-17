using lab_1_toliik_nooolik;
class Program
{
    static void Main()
    {
        WordProvider wordProvider = new WordProvider();
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


            Console.WriteLine("\nЩе раз?  (y/n)");
            string choice = Console.ReadLine().ToLower();
            if (choice != "y" && choice != "n")
            {
                wantToPlay = false;
            }
        }

        Console.WriteLine("Бувай");
    }
}
// Done.