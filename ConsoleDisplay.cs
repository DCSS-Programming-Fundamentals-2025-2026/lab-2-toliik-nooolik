public static class GameInterface
{
    public static void Render(HangmanEngine engine)
    {
        Console.Clear();
        Console.WriteLine("HANGMAN");
        Console.WriteLine($"\nСлово: {engine.GetDisplayWord()}");
        Console.WriteLine($"Залишилось спроб: {engine.CurrentLives} / {engine.MaxLives}");

        
        for (int i = 0; i < engine.CurrentLives; i++) Console.Write("❤");
        Console.WriteLine("\n--------------------");
    }

    public static char AskLetter()
    {
        Console.Write("Введіть букву ");
        string input = Console.ReadLine();
        return (input != null && input.Length > 0) ? input[0] : ' ';
    }
}