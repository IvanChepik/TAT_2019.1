using System;
using NUnit.Framework;
using DEV_2;

namespace DEV_2.Tests
{
    /// <summary>
    /// Class CreateWordTests
    /// tests for creating word.
    /// </summary>
    [TestFixture]
    public class CreateWordTests
    {
        /// <summary>
        /// Method CreateWordTest
        /// tests creating word.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="expectedWord"></param>
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

        /// <summary>
        /// Method CreateWordRussianTest
        /// Negative tests for CreateWord
        /// </summary>
        /// <param name="word"></param>
        /// <param name="exception"></param>
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

        /// <summary>
        /// Method CreateWordNullTest
        /// Negative null tests for CreateWord 
        /// </summary>
        /// <param name="word"></param>
        /// <param name="exception"></param>
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

        /// <summary>
        /// Method CreateWordArgumentTest
        /// tests word creating for empty.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="exception"></param>
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