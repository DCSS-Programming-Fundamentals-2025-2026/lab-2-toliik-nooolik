using System;
using System.Text;
using System.Collections;

public class GameController
{
    private int winCount = 0;
    private int lossCount = 0;
    private IWordProvider wordProvider;

    private GameWordCollection wordsRepo = new GameWordCollection(10);
    public GameController()
    {
        wordProvider = new StaticWordProvider();

        wordsRepo.Add(new GameWord("яблуко", "фрукт"));
        wordsRepo.Add(new GameWord("банан", "жовтий"));
    }

    
    public void Start()
    {
        Console.OutputEncoding = Encoding.UTF8; 

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1 - Грати");
            Console.WriteLine("2 - Статистика");
            Console.WriteLine("3 - Словник"); 
            Console.WriteLine("0 - Вихід"); 
            Console.WriteLine("====================");
            

            string menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    PlayGameRound();
                    break;
                case "2":
                    ShowStatistics();
                    break;
                case "3": 
                    ShowLabDemo();
                    break;
                case "0":
                    Console.WriteLine("\nДякую за гру!");
                    return;
                default:
                    Console.WriteLine("\nНевірний вибір. Натисніть будь-яку клавішу...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void ShowLabDemo()
    {
        Console.Clear();
        Console.WriteLine("1. Сортувати A-Z | 2. Сортувати за довжиною | 3. Видалити слово");
        string op = Console.ReadLine();
        
        if (op == "1") wordsRepo.Sort(); 
        if (op == "2") wordsRepo.Sort(new WordLengthComparer()); 
        if (op == "3") wordsRepo.Add(new GameWord("тест", "тест")); 
        if (op == "3") wordsRepo.RemoveAt(0);
        
        Console.WriteLine("\nВміст словника:");
        var it = wordsRepo.GetEnumerator();
        while (it.MoveNext()) 
        {
            GameWord w = (GameWord)it.Current;
            Console.WriteLine($"- {w.Text}");
        }
        Console.ReadKey();
    }

    private void PlayGameRound()
    {
        string secret = wordProvider.GetWord();
        string hint = wordProvider.GetHint();

        int maxAttempts = 7;
        HangmanGame game = new HangmanGame(secret, maxAttempts);

        while (!game.IsGameOver())
        {
            Console.Clear();
            Console.WriteLine("=== HANGMAN ===");
            Console.WriteLine($"ПІДКАЗКА: {hint}");
            Console.WriteLine("---------------------------------");

            Console.WriteLine($"Прогрес: {game.GetProgressString()}");

            Console.WriteLine($"Життя : {game.AttemptsLeft} / {maxAttempts}");
            for (int i = 0; i < game.AttemptsLeft; i++)
            {
                Console.Write("❤ ");
            }
            Console.WriteLine("\n---------------------------------");

            Console.Write("Введіть літеру: ");

            string input = Console.ReadLine();
            char guess = (input != null && input.Length > 0) ? input[0] : ' ';

            game.MakeGuess(guess);
        }

        Console.Clear();
        Console.WriteLine("=== РЕЗУЛЬТАТ ГРИ ===");
        Console.WriteLine($"Фінальний прогрес: {game.GetProgressString()}");

        if (game.IsWon())
        {
            Console.WriteLine("\n[Win] Ви відгадали слово!");
            winCount++;
        }
        else
        {
            Console.WriteLine($"\n[Lose] Спроби закінчилися. Загадане слово: {game.GetSecretWord()}");
            lossCount++;
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутися до меню...");
        Console.ReadKey();
    }

    private void ShowStatistics()
    {
        Console.Clear();
        Console.WriteLine("=== СТАТИСТИКА ===");
        Console.WriteLine($"Перемоги: {winCount}");
        Console.WriteLine($"Поразки:  {lossCount}");
        Console.WriteLine($"Слів у колекції: {wordsRepo.Count}");
    
        int totalGames = winCount + lossCount;
        if (totalGames > 0)
        {
            int winRate = (winCount * 100) / totalGames;
            Console.WriteLine($"Відсоток перемог: {winRate}%");
        }

        Console.WriteLine("==================");
        Console.WriteLine("Натисніть будь-яку клавішу для повернення...");
        Console.ReadKey();
    }
}