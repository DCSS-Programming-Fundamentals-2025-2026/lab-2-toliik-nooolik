using NUnit.Framework;
using lab_1_toliik_nooolik;

namespace hangman.Tests
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
            int lives = 5;

            var game = new HangmanEngine(word, lives);

            Assert.AreEqual(lives, game.CurrentLives);       
            Assert.AreEqual(lives, game.MaxLives);           
            Assert.AreEqual("____", game.GetDisplayWord());  
        }

        
        [Test]
        public void MakeGuess_ValidLetter_ShouldRevealLetter()
        {
            var game = new HangmanEngine("Cat", 5);

            bool result = game.MakeGuess('a');

            Assert.IsTrue(result);                           
            Assert.AreEqual("_a_", game.GetDisplayWord());   
            Assert.AreEqual(5, game.CurrentLives);           
        }

        
        [Test]
        public void MakeGuess_InvalidLetter_ShouldDecreaseLives()
        {
            var game = new HangmanEngine("Cat", 5);

            bool result = game.MakeGuess('z'); 
 
            Assert.IsFalse(result);         
            Assert.AreEqual(4, game.CurrentLives);
        }

        
        [Test]
        public void MakeGuess_UpperCaseLetter_ShouldWorkAsLowerCase()
        {
            var game = new HangmanEngine("Cat", 5);

            bool result = game.MakeGuess('C');

            Assert.IsTrue(result);
            Assert.AreEqual("c__", game.GetDisplayWord()); 
        }

       
        [Test]
        public void IsWon_WhenAllLettersGuessed_ShouldReturnTrue()
        {
            var game = new HangmanEngine("Hi", 3);

            game.MakeGuess('h');
            game.MakeGuess('i');

            Assert.IsTrue(game.IsWon());      
            Assert.IsTrue(game.IsGameOver()); 
        }

        [Test]
        public void IsGameOver_WhenLivesZero_ShouldReturnTrue()
        {
            var game = new HangmanEngine("Hi", 1); 

            game.MakeGuess('z'); 

            Assert.AreEqual(0, game.CurrentLives);
            Assert.IsTrue(game.IsGameOver());
        }

        [Test]
        public void GameScenario_PlaySeveralRounds_CheckState()
        {
            var game = new HangmanEngine("Banana", 3);

            game.MakeGuess('a'); 
            game.MakeGuess('x'); 

            Assert.AreEqual("_a_a_a", game.GetDisplayWord()); 
            Assert.AreEqual(2, game.CurrentLives);            
            Assert.IsFalse(game.IsGameOver());                
        }
    
    
        [Test]
        public void GameScenario_LoseGame_CheckZeroLives()
        { 
            var game = new HangmanEngine("Dog", 2); 

            game.MakeGuess('z'); 
            game.MakeGuess('x'); 

            Assert.AreEqual(0, game.CurrentLives);
            Assert.IsTrue(game.IsGameOver()); 
            Assert.IsFalse(game.IsWon());     
        }
    }
}


