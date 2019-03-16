using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace DEV_2
{
    class PhoneticConverter
    {
        public string GetPhoneticRepresentation(string receivedString)
        {
            if (receivedString == null)
            {
                throw new ArgumentNullException("Your string is null");
            }
            receivedString = receivedString.Replace(" ", string.Empty);
            if (receivedString.Length == 0)
            {
                throw new ArgumentException("Your string is empty");
            }
            receivedString = ReplaceOSymbolsWithouAccent(receivedString);
            receivedString = ReplaceSonantAndSharp(receivedString);
            receivedString = ReplaceVowelsOnSounds(receivedString);
            return receivedString;
        }
        private string ReplaceOSymbolsWithouAccent(string receivedString)
        {
            return new string(receivedString
                            .Select((e, i) => (e == 'о') && (i == receivedString.Length - 1 || receivedString[i + 1] != '+') ? 'а' : e)
                            .Where(e => e != '+')
                            .ToArray());
        }
        private string ReplaceSonantAndSharp(string receivedString)
        {
            var result = new StringBuilder(receivedString);
            if (SonantToSharpDictionary.ContainsKey(result[result.Length-1]))
            {
                result[result.Length - 1] = SonantToSharpDictionary[result[result.Length - 1]];
            }
            for (var i = result.Length - 1; i > 0; i--)
            {
                if (SonantToSharpDictionary.ContainsValue(result[i]) && SonantToSharpDictionary.ContainsKey(result[i - 1]))
                {
                    result[i - 1] = SonantToSharpDictionary[result[i - 1]];                  
                }
                if (SharpToSonantDictionary.ContainsValue(result[i]) &&  SharpToSonantDictionary.ContainsKey(result[i - 1]))
                {
                    result[i - 1] = SharpToSonantDictionary[result[i - 1]];
                }
            }
            return result.ToString();
        }

        private string ReplaceVowelsOnSounds(string receivedString)
        {
            var result = new StringBuilder(receivedString);
            for (var i = receivedString.Length - 1; i >= 0; i--)
            {
                if (VowelsSoundsDictionary.ContainsKey(result[i]) && (i == 0 || vowels.Contains(result[i - 1])))
                {
                    result[i] = VowelsSoundsDictionary[result[i]];
                    result.Insert(i, "й'");
                }

                if (VowelsSoundsDictionary.ContainsKey(result[i]) && (sonorous.Contains(result[i-1]) || SonantToSharpDictionary.ContainsKey(result[i-1]) || SharpToSonantDictionary.ContainsKey(result[i-1])))
                {
                    result[i] = VowelsSoundsDictionary[result[i]];
                    result.Insert(i, '\'');
                }
            }
            return result.ToString();
        }

        private readonly List<char> sonorous = new List<char>()
        {
            'н', 'р', 'м', 'л', 'й', 
        };

        private readonly List<char> vowels = new List<char>()
        {
            'а', 'о', 'э', 'и', 'у', 'ы', 'е', 'ё', 'ю', 'я',
        };

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
