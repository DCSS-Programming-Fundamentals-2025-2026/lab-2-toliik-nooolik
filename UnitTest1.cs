using NUnit.Framework;


namespace TestHangman
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        
        [Test]
        public void Constructor_ShouldInitializeCorrectly()
        {
            
            string word = "Test";
            int attempts = 5;

            var game = new HangmanGame(word, attempts);

            Assert.AreEqual(attempts, game.AttemptsLeft);
            Assert.AreEqual("____", game.GetProgressString()); 
        }

        [Test]
        public void MakeGuess_ValidLetter_ShouldRevealLetter()
        {
            var game = new HangmanGame("Cat", 5);

            bool result = game.MakeGuess('a');

            Assert.IsTrue(result);
            Assert.AreEqual("_a_", game.GetProgressString());
            Assert.AreEqual(5, game.AttemptsLeft); 
        }

        [Test]
        public void MakeGuess_InvalidLetter_ShouldDecreaseAttempts()
        {
            var game = new HangmanGame("Cat", 5);

            bool result = game.MakeGuess('z');

            Assert.IsFalse(result);
            Assert.AreEqual(4, game.AttemptsLeft); 
        }

        [Test]
        public void MakeGuess_UpperCaseLetter_ShouldWorkAsLowerCase()
        {
            var game = new HangmanGame("Cat", 5);

            bool result = game.MakeGuess('C'); 

            Assert.IsTrue(result);
            Assert.AreEqual("c__", game.GetProgressString()); 
        }

        [Test]
        public void IsWon_WhenAllLettersGuessed_ShouldReturnTrue()
        {
            var game = new HangmanGame("Hi", 3);

            game.MakeGuess('h');
            game.MakeGuess('i');

            Assert.IsTrue(game.IsWon());
            Assert.IsTrue(game.IsGameOver());
        }

        
        [Test]
        public void IsGameOver_WhenAttemptsZero_ShouldReturnTrue()
        {
            var game = new HangmanGame("Hi", 1);

            game.MakeGuess('z'); 

            Assert.AreEqual(0, game.AttemptsLeft);
            Assert.IsTrue(game.IsGameOver());
        }

        [Test]
        public void GameScenario_PlaySeveralRounds_CheckState()
        {
            var game = new HangmanGame("Banana", 3);

            game.MakeGuess('a'); 
            game.MakeGuess('x'); 

            Assert.AreEqual("_a_a_a", game.GetProgressString());
            Assert.AreEqual(2, game.AttemptsLeft);
            Assert.IsFalse(game.IsGameOver());
        }

        
        [Test]
        public void GameScenario_LoseGame_CheckZeroAttempts()
        {
            var game = new HangmanGame("Dog", 2);

            game.MakeGuess('z'); 
            game.MakeGuess('x'); 

            Assert.AreEqual(0, game.AttemptsLeft);
            Assert.IsTrue(game.IsGameOver());
            Assert.IsFalse(game.IsWon());
        }
    }
}