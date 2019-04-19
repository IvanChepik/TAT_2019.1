using System;
using NUnit.Framework;
using DEV_2;

namespace DEV_2.Tests
{
    /// <summary>
    /// Class GetPhoneticRepresentationTests
    /// Tests GetPhoneticRepresentationTests method 
    /// </summary>
    [TestFixture]
    public class GetPhoneticRepresentationTests
    {
        /// <summary>
        /// Method GetPhoneticRepresentationTest
        /// positive tests for GetPhoneticRepresentationTest
        /// </summary>
        /// <param name="word"></param>
        /// <param name="expectedPhoneme"></param>
        [TestCase("зуб", "зуп")]
        [TestCase("вью+га", "в'й'уга")]
        [TestCase("ёлка","й'олка")]
        [TestCase("моё", "май'о")]
        [TestCase("ме+сто", "м'эста")]
        [TestCase("тря+пка", "тр'апка")]
        [TestCase("молоко+", "малако")]
        public void GetPhoneticRepresentationTest(string word, string expectedPhoneme)
        {
            var phoneticConverter = new PhoneticConverter();
            var result = phoneticConverter.GetPhoneticRepresentation(word);
            Assert.AreEqual(expectedPhoneme, result);
        }

        /// <summary>
        /// Method GetPhoneticAccentRepresentationTest
        /// Negative tests for wrong accents
        /// </summary>
        /// <param name="word"></param>
        [TestCase("зуб+")]
        [TestCase("+моё")]
        [TestCase("белый")]
        [TestCase("ёжи+к")]
        [TestCase("мо++локо")]
        [TestCase("мо+локо+")]
        [TestCase("рёварё")]
        [TestCase("+")]
        public void GetPhoneticAccentRepresentationTest(string word)
        {
            var phoneticConverter = new PhoneticConverter();
            Assert.Throws<AccentException>
            (
                () => phoneticConverter.GetPhoneticRepresentation(word)
            );
        }

        /// <summary>
        /// Method GetPhoneticArgumentRepresentationTest
        /// tests for empty
        /// </summary>
        /// <param name="word"></param>
        [TestCase("")]
        public void GetPhoneticArgumentRepresentationTest(string word)
        {
            var phoneticConverter = new PhoneticConverter();
            Assert.Throws<ArgumentException>
            (
                () => phoneticConverter.GetPhoneticRepresentation(word)
            );
        }

        /// <summary>
        /// Method GetPhoneticArgumentRepresentationTest
        /// tests for null
        /// </summary>
        /// <param name="word"></param>
        [TestCase(null)]
        public void GetPhoneticArgumentNullRepresentationTest(string word)
        {
            var phoneticConverter = new PhoneticConverter();
            Assert.Throws<ArgumentNullException>
            (
                () => phoneticConverter.GetPhoneticRepresentation(word)
            );
        }

        /// <summary>
        /// Method GetPhoneticRussianWordRepresentationTest
        /// test for non Russian Word
        /// </summary>
        /// <param name="word"></param>
        [TestCase("begi+n")]
        [TestCase("маshi+na")]
        [TestCase("мол......око+")]
        [TestCase("мол,око+")]
        [TestCase("мол!!!око+")]
        public void GetPhoneticRussianWordRepresentationTest(string word)
        {
            var phoneticConverter = new PhoneticConverter();
            Assert.Throws<NotRussianWordException>
            (
                () => phoneticConverter.GetPhoneticRepresentation(word)
            );
        }

    }
}