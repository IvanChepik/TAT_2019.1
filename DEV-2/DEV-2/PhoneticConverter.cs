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
        private Word _word;

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

            this._word = new Word(receivedString);

            if (!CheckAccent())
            {
                throw new AccentException("Your _word has wrong accent format");
            }

            ReplaceOSymbolsWithouAccent();
            ReplaceSonantAndSharp();
            ReplaceVowelsOnSounds();
            ReplaceSigns();

            return this._word.Value;
        }

        /// <summary>
        /// method ReplaceOSymbolsWithoutAccent 
        /// replace 'o' without accent on 'a'
        /// </summary>
        private void ReplaceOSymbolsWithouAccent()
        {           
            for (var i = 0; i < this._word.Length; i++)
            {
                if(this._word.Value[i] == 'о' && (i == this._word.Length - 1 || this._word.Value[i + 1] != '+') && this._word.CountOfVowels > 1)
                {
                    this._word.Replace(i, 'а');
                }               
            }

            this._word.Remove('+');
        }

        /// <summary>
        /// method ReplaceSonantAndSharp 
        /// replace sonant and sharp on the principle of regressive assimilation
        /// </summary>
        private void ReplaceSonantAndSharp()
        {
            if (_sonantToSharpDictionary.ContainsKey(this._word.Value[this._word.Length-1]))
            {
                this._word.Replace(this._word.Length - 1, _sonantToSharpDictionary[this._word.Value[this._word.Length - 1]]);
            }

            for (var i = this._word.Length - 1; i > 0; i--)
            {
                if (_sonantToSharpDictionary.ContainsValue(this._word.Value[i])) 
                {
                    if ((this._word.Value[i-1] == 'ь' || this._word.Value[i-1] == 'ъ') && _sonantToSharpDictionary.ContainsKey(this._word.Value[i-2]))
                    {
                        this._word.Replace(i - 2, _sonantToSharpDictionary[this._word.Value[i - 2]]);
                    }
                    else if (_sonantToSharpDictionary.ContainsKey(this._word.Value[i - 1]))
                    {
                        this._word.Replace(i - 1, _sonantToSharpDictionary[this._word.Value[i - 1]]);
                    }
                }   
                
                if (_sharpToSonantDictionary.ContainsValue(this._word.Value[i]))  
                {
                    if ((this._word.Value[i - 1] == 'ь' || this._word.Value[i - 1] == 'ъ') && _sharpToSonantDictionary.ContainsKey(this._word.Value[i - 2]))
                    {
                        this._word.Replace(i - 2, _sharpToSonantDictionary[this._word.Value[i - 2]]);
                    }
                    else if (_sharpToSonantDictionary.ContainsKey(_word.Value[i - 1]))
                    {
                        this._word.Replace(i - 1, _sharpToSonantDictionary[this._word.Value[i - 1]]);
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
            for (var i = _word.Length - 1; i >= 0; i--)
            {
                if (_vowelsSoundsDictionary.ContainsKey(_word.Value[i]))
                {
                    if (_word.CheckOfBeforeNoConsonat(i))
                    {
                        this._word.Replace(i, _vowelsSoundsDictionary[this._word.Value[i]]);
                        this._word.Insert(i, "й'");
                    }
                    else
                    {
                        this._word.Replace(i, _vowelsSoundsDictionary[this._word.Value[i]]);
                        this._word.Insert(i, "\'");
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
            _word.Replace("ь", "\'");
            _word.Replace("ъ", "");
        }

        /// <summary>
        /// Method CheckAccent 
        /// check wrong accent
        /// </summary>
        /// <returns>return false is accents wrong</returns>
        private bool CheckAccent()
        {
            var numberOfAccents = this._word.Value.Count(e => e == '+');

            if(numberOfAccents > 1)
            {
                return false;
            }

            var numberOfAlwaysAccent = this._word.Value.Count(e => e == 'ё');

            if (numberOfAlwaysAccent > 1)
            {
                return false;
            }

            switch (numberOfAccents)
            {
                case 0 when (this._word.CountOfVowels == 1 || this._word.Value.Contains('ё')):
                    return true;
                case 1 when this._word.Value[0] == '+':
                case 1 when this._word.Value.Contains('ё') && this._word.Value[this._word.Find('ё')+1] != '+':
                    return false;
                case 1:
                    return (this._word.Letters.Vowels.Contains(this._word.Value[this._word.Find('+')-1]) || this._word.Value[this._word.Find('+') - 1] == 'ё');
                default:
                    return false;
            }
        }        

        private readonly Dictionary<char, char> _sonantToSharpDictionary = new Dictionary<char, char>()
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

        private readonly Dictionary<char, char> _sharpToSonantDictionary = new Dictionary<char, char>()
        {
            ['п'] = 'б',
            ['ф'] = 'в',
            ['т'] = 'д',
            ['с'] = 'з',
            ['ш'] = 'ж',
            ['к'] = 'г',
        };

        private readonly Dictionary<char, char> _vowelsSoundsDictionary = new Dictionary<char, char>()
        {
            ['е'] = 'э',
            ['ё'] = 'о',
            ['ю'] = 'у',
            ['я'] = 'а',
        };
    }
}
