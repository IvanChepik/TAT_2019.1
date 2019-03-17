using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace DEV_2
{
    public class PhoneticConverter
    {
        private Word word;
        public string GetPhoneticRepresentation(string receivedString)
        {
            if (receivedString == null)
            {
                throw new ArgumentNullException("Your string is null");
            }
            receivedString = receivedString.Replace(" ", string.Empty).ToLower();
            if (receivedString.Length == 0)
            {
                throw new ArgumentException("Your string is empty");
            }
            word = new Word(receivedString);
            //посмотреть сколько слогов(сколько содержится гласных), если нет ударение и слогов два говно, если есть ё и ударение не на ё пошел нахуй, если нет плюса и есть ё то все норм
            ReplaceOSymbolsWithouAccent();
            ReplaceSonantAndSharp();
            ReplaceVowelsOnSounds();
            return word.Value;
        }
        private void ReplaceOSymbolsWithouAccent()
        {           
            for (var i = 0; i < word.Length; i++)
            {
                if(word.Value[i] == 'о' && (i == word.Length - 1 || word.Value[i + 1] != '+'))
                {
                    word.Replace(i, 'а');
                }
            }
        }
        private void ReplaceSonantAndSharp()
        {
            if (SonantToSharpDictionary.ContainsKey(word.Value[word.Length-1]))
            {                
                word.Replace(word.Length - 1, SonantToSharpDictionary[word.Value[word.Length - 1]]);
            }
            for (var i = word.Length - 1; i > 0; i--)
            {
                if (SonantToSharpDictionary.ContainsValue(word.Value[i]) && SonantToSharpDictionary.ContainsKey(word.Value[i - 1]))
                {
                    word.Replace(i - 1, SonantToSharpDictionary[word.Value[i - 1]]);
                }
                if (SharpToSonantDictionary.ContainsValue(word.Value[i]) && SharpToSonantDictionary.ContainsKey(word.Value[i - 1]))
                {
                    word.Replace(i - 1, SharpToSonantDictionary[word.Value[i - 1]]);
                }
            }
        }
        private void ReplaceVowelsOnSounds()
        {
            for (var i = word.Length - 1; i >= 0; i--)
            {
                if (VowelsSoundsDictionary.ContainsKey(word.Value[i]))
                {
                    if (word.CheckOfBeforeNoConsonat(i))
                    {
                        word.Replace(i, VowelsSoundsDictionary[word.Value[i]]);
                        word.Insert(i, "й'");
                    }
                    else
                    {
                        word.Replace(i, VowelsSoundsDictionary[word.Value[i]]);
                        word.Insert(i, "\'");
                    }
                }       
            }
        }

        private readonly Dictionary<char, char> SonantToSharpDictionary = new Dictionary<char, char>()
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['д'] = 'т',
            ['з'] = 'с',
            ['ж'] = 'ш',
            ['г'] = 'к',
            ['х'] = 'х',
            ['ц'] = 'ц',
            ['ч'] = 'ч',
            ['щ'] = 'щ',
        };

        private readonly Dictionary<char, char> SharpToSonantDictionary = new Dictionary<char, char>()
        {
            ['п'] = 'б',
            ['ф'] = 'в',
            ['т'] = 'д',
            ['с'] = 'з',
            ['ш'] = 'ж',
            ['к'] = 'г',
        };

        private readonly Dictionary<char, char> VowelsSoundsDictionary = new Dictionary<char, char>()
        {
            ['е'] = 'э',
            ['ё'] = 'о',
            ['ю'] = 'у',
            ['я'] = 'а',
        };
    }
}
