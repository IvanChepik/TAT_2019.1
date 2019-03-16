using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DEV_2
{
    class PhoneticConverter
    {
        public string GetPhoneticRepresentation(string receivedString)
        {
            receivedString = ReplaceOSymbolsWithouAccent(receivedString);
            receivedString = ReplaceSonantAndSharp(receivedString);
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
            if (SonantToVowelDictionary.ContainsKey(result[result.Length-1]))
            {
                result[result.Length - 1] = SonantToVowelDictionary[result[result.Length - 1]];
            }
            for (var i = result.Length - 1; i > 0; i--)
            {
                if (SonantToVowelDictionary.ContainsValue(result[i]) && SonantToVowelDictionary.ContainsKey(result[i - 1]))
                {
                    result[i - 1] = SonantToVowelDictionary[result[i - 1]];                  
                }
                if (VowelToSonantDictionary.ContainsValue(result[i]) &&  VowelToSonantDictionary.ContainsKey(result[i - 1]))
                {
                    result[i - 1] = VowelToSonantDictionary[result[i - 1]];
                }
            }
            return result.ToString();
        }
        private readonly Dictionary<char, char> SonantToVowelDictionary = new Dictionary<char, char>()
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

        private readonly Dictionary<char, char> VowelToSonantDictionary = new Dictionary<char, char>()
        {
            ['п'] = 'б',
            ['ф'] = 'в',
            ['т'] = 'д',
            ['с'] = 'з',
            ['ш'] = 'ж',
            ['к'] = 'г',
        };

    }
}
