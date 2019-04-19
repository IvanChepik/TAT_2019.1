using System;
using NUnit.Framework;
using DEV_2;

namespace DEV_2.Tests
{
    [TestFixture]
    public class GetPhoneticRepresentationTests
    {
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
       
        [TestCase("")]
        public void GetPhoneticArgumentRepresentationTest(string word)
        {
            var phoneticConverter = new PhoneticConverter();
            Assert.Throws<ArgumentException>
            (
                () => phoneticConverter.GetPhoneticRepresentation(word)
            );
        }

        [TestCase(null)]
        public void GetPhoneticArgumentNullRepresentationTest(string word)
        {
            var phoneticConverter = new PhoneticConverter();
            Assert.Throws<ArgumentNullException>
            (
                () => phoneticConverter.GetPhoneticRepresentation(word)
            );
        }

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