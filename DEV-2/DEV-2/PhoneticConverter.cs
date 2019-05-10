using System.Linq;
using System.Collections.Generic;
using System;

namespace DEV_2
{/// <summary>
/// Class Phonetic Convertor
/// take string, create new word and convert it to phonetic 
/// </summary>
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
            if (!CheckAccent())
            {
                throw new ArgumentException("Your word has wrong accent format");
            }
            ReplaceOSymbolsWithouAccent();
            ReplaceSonantAndSharp();
            ReplaceVowelsOnSounds();
            ReplaceSigns();
            return word.Value;
        }
        /// <summary>
        /// method ReplaceOSymbolsWithoutAccent 
        /// replace 'o' without accent on 'a'
        /// </summary>
        private void ReplaceOSymbolsWithouAccent()
        {           
            for (var i = 0; i < word.Length; i++)
            {
                if(word.Value[i] == 'о' && (i == word.Length - 1 || word.Value[i + 1] != '+') && word.CountOfVowels > 1)
                {
                    word.Replace(i, 'а');
                }               
            }
            word.Remove('+');
        }
        /// <summary>
        /// method ReplaceSonantAndSharp 
        /// replace sonant and sharp on the principle of regressive assimilation
        /// </summary>
        private void ReplaceSonantAndSharp()
        {
            if (SonantToSharpDictionary.ContainsKey(word.Value[word.Length-1]))
            {                
                word.Replace(word.Length - 1, SonantToSharpDictionary[word.Value[word.Length - 1]]);
            }
            for (var i = word.Length - 1; i > 0; i--)
            {
                if (SonantToSharpDictionary.ContainsValue(word.Value[i])) 
                {
                    if ((word.Value[i-1] == 'ь' || word.Value[i-1] == 'ъ') && SonantToSharpDictionary.ContainsKey(word.Value[i-2]))
                    {   
                        word.Replace(i - 2, SonantToSharpDictionary[word.Value[i - 2]]);
                    }
                    else if (SonantToSharpDictionary.ContainsKey(word.Value[i - 1]))
                    {
                        word.Replace(i - 1, SonantToSharpDictionary[word.Value[i - 1]]);
                    }
                }               
                if (SharpToSonantDictionary.ContainsValue(word.Value[i]))  
                {
                    if ((word.Value[i - 1] == 'ь' || word.Value[i - 1] == 'ъ') && SharpToSonantDictionary.ContainsKey(word.Value[i - 2]))
                    {
                        word.Replace(i - 2, SharpToSonantDictionary[word.Value[i - 2]]);
                    }
                    else if (SharpToSonantDictionary.ContainsKey(word.Value[i - 1]))
                    {
                        word.Replace(i - 1, SharpToSonantDictionary[word.Value[i - 1]]);
                    }
                }
            }
        }
        /// <summary>
        /// method ReplaceVowelsOnSounds
        /// replace all vowel on phonetic depending on the preceding letter
        /// </summary>
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
        /// <summary>
        /// method ReplaceSigns 
        /// replaces all soft and hard signs on ' or remove it
        /// </summary>
        private void ReplaceSigns()
        {
            word.Replace("ь", "\'");
            word.Replace("ъ", "");
        }
        /// <summary>
        /// Method CheckAccent 
        /// check wrong accent
        /// </summary>
        /// <returns>return false is accents wrong</returns>
        private bool CheckAccent()
        {
            var numberOfAccents = word.Value.Count(e => e == '+');
            if(numberOfAccents > 1)
            {
                return false;
            }
            var numberOfAlwaysAccent = word.Value.Count(e => e == 'ё');
            if (numberOfAlwaysAccent > 1)
            {
                return false;
            }
            if(numberOfAccents == 0 && (word.CountOfVowels == 1 || word.Value.Contains('ё')))
            {
                return true;
            }
            if(numberOfAccents == 1)
            {
                if (word.Value[0] == '+')
                {
                    return false;
                }
                if (word.Value.Contains('ё') && word.Value[word.Find('ё')+1] != '+')
                {
                    return false;
                }
                return (word.letters.vowels.Contains(word.Value[word.Find('+')-1]) || word.Value[word.Find('+') - 1] == 'ё');
            }
            return false;
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
