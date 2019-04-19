using System;
using NUnit.Framework;

namespace DEV_2.Tests
{
    /// <summary>
    /// Class WordOperationTests
    /// tests Word Operation 
    /// </summary>
    [TestFixture]
    public class WordOperationTests
    {
        /// <summary>
        /// method ReplaceTest
        /// Positive Test method Replace
        /// </summary>
        /// <param name="word"></param>
        /// <param name="indexOldSymbol"></param>
        /// <param name="newSymbol"></param>
        /// <param name="expectedWord"></param>
        [TestCase("зуб", 1, 'а',  "заб")]
        [TestCase("молоко", 0, 'з', "золоко")]
        [TestCase("белый", 4, 'м', "белым")]
        public void ReplaceTest(string word, int indexOldSymbol, char newSymbol, string expectedWord)
        {
            var resultWord = new Word(word);
            resultWord.Replace(indexOldSymbol, newSymbol);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }

        /// <summary>
        /// method ReplaceNegativeTest
        /// Negative method for Replace method.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="indexOldSymbol"></param>
        /// <param name="newSymbol"></param>
        [TestCase("зуб", 10, 'а')]
        [TestCase("молоко", -1, 'з')]
        public void ReplaceNegativeTest(string word, int indexOldSymbol, char newSymbol)
        {
            var resultWord = new Word(word);
            Assert.Throws<ArgumentOutOfRangeException>
            (
                () => resultWord.Replace(indexOldSymbol, newSymbol)
            );
        }

        /// <summary>
        /// Method ReplaceCharTest
        /// Positive tests ReplaceCharTest
        /// </summary>
        /// <param name="word"></param>
        /// <param name="oldSymbol"></param>
        /// <param name="newSymbol"></param>
        /// <param name="expectedWord"></param>
        [TestCase("зуб", "у", "а", "заб")]
        [TestCase("молоко", "м", "з", "золоко")]
        [TestCase("белый", "й", "м", "белым")]
        [TestCase("зуб", "м", "а", "зуб")]
        public void ReplaceCharTest(string word, string oldSymbol, string newSymbol, string expectedWord)
        {
            var resultWord = new Word(word);
            resultWord.Replace(oldSymbol, newSymbol);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }

        /// <summary>
        /// Method PositiveInsertTest
        /// Positive tests method Insert
        /// </summary>
        /// <param name="word"></param>
        /// <param name="indexOfSymbol"></param>
        /// <param name="newSymbols"></param>
        /// <param name="expectedWord"></param>
        [TestCase("беляна", 2, "ф", "бефляна")]
        [TestCase("молоко", 0, "зеб", "зебмолоко")]
        [TestCase("беляна", 6, "ф", "белянаф")]
        public void PositiveInsertTest(string word, int indexOfSymbol, string newSymbols, string expectedWord)
        {
            var resultWord = new Word(word);
            resultWord.Insert(indexOfSymbol, newSymbols);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }

        /// <summary>
        /// Method NegativeInsertTest
        /// Negative test for NegativeInsertTest
        /// </summary>
        /// <param name="word"></param>
        /// <param name="indexOfSymbol"></param>
        /// <param name="newSymbols"></param>
        [TestCase("беляна", 13, "ф")]
        [TestCase("молоко", -1, "зеб")]
        public void NegativeInsertTest(string word, int indexOfSymbol, string newSymbols)
        {
            var resultWord = new Word(word);
            Assert.Throws<ArgumentOutOfRangeException>
            (
                () => resultWord.Insert(indexOfSymbol, newSymbols)
            );
        }
    }

}