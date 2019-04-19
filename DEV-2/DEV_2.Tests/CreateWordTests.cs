using System;
using NUnit.Framework;
using DEV_2;

namespace DEV_2.Tests
{
    [TestFixture]
    public class CreateWordTests
    {
        [TestCase("зуб", "зуб")]
        [TestCase("вью+га", "вью+га")]
        [TestCase("ёлка", "ёлка")]
        [TestCase("моё", "моё")]
        [TestCase("ме+сто", "ме+сто")]
        [TestCase("тря+пка", "тря+пка")]
        [TestCase("молоко+", "молоко+")]
        public void CreateWordTest(string word, string expectedWord)
        {
            var resultWord = new Word(word);
            Assert.AreEqual(expectedWord, resultWord.Value);
        }

        [TestCase("begi+n", typeof(NotRussianWordException))]
        [TestCase("маshi+na", typeof(NotRussianWordException))]
        [TestCase("мол......око+", typeof(NotRussianWordException))]
        [TestCase("мол,око+", typeof(NotRussianWordException))]
        [TestCase("мол!!!око+",typeof(NotRussianWordException))]
        public void CreateWordRussianTest(string word, Type exception)
        {
            try
            {
               new Word(word);
            }
            catch 
            {
                Assert.AreEqual(exception, typeof(NotRussianWordException));
            }
        }

        [TestCase(null,typeof(ArgumentNullException))]
        public void CreateWordNullTest(string word, Type exception)
        {
            try
            {
                new Word(word);
            }
            catch
            {
                Assert.AreEqual(exception, typeof(ArgumentNullException));
            }
        }

        [TestCase("", typeof(ArgumentException))]
        public void CreateWordArgumentTest(string word, Type exception)
        {
            try
            {
                new Word(word);
            }
            catch
            {
                Assert.AreEqual(exception, typeof(ArgumentException));
            }
        }
    }
}