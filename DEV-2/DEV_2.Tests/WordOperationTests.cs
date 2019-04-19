using System;
using NUnit.Framework;

namespace DEV_2.Tests
{
    [TestFixture]
    public class WordOperationTests
    {
        [TestCase("зуб", 1, 'а',  "заб")]
        [TestCase("молоко", 0, 'з', "золоко")]
        [TestCase("белый", 4, 'м', "белым")]
        public void ReplaceTest(string word, int indexOldSymbol, char newSymbol, string expectedWord)
        {
            var resultWord = new Word(word);
            resultWord.Replace(indexOldSymbol, newSymbol);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }

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

        [TestCase("беляна", 2, "ф", "бефляна")]
        [TestCase("молоко", 0, "зеб", "зебмолоко")]
        [TestCase("беляна", 6, "ф", "белянаф")]
        public void Insert(string word, int indexOfSymbol, string newSymbols, string expectedWord)
        {
            var resultWord = new Word(word);
            resultWord.Insert(indexOfSymbol, newSymbols);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }

        [TestCase("беляна", 13, "ф")]
        [TestCase("молоко", -1, "зеб")]
        public void Insert(string word, int indexOfSymbol, string newSymbols)
        {
            var resultWord = new Word(word);
            Assert.Throws<ArgumentOutOfRangeException>
            (
                () => resultWord.Insert(indexOfSymbol, newSymbols)
            );
        }

        [TestCase("беляна", 'е', "бляна")]
        [TestCase("молоко", 'м', "олоко")]
        public void Remove(string word, char symbol, string expectedWord)
        {
            var resultWord = new Word(word);
            resultWord.Remove(symbol);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }
    }

}