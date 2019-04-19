using System.Text;
using System.Linq;
using System;

namespace DEV_2
{
    /// <summary>
    /// class Word
    /// encapsulates StringBuilder to work with string
    /// </summary>
    public class Word
    {
        private readonly StringBuilder _word;

        public Letters Letters = new Letters();

        public string Value => this._word.ToString();

        public int Length => this.Value.Length;

        /// <summary>
        /// Constructor Word
        /// determines word and check 
        /// </summary>
        /// <param name="receivedString"></param>
        public Word(string receivedString)
        {
            if(!this.CheckOnRussian(receivedString))
            {
                throw new NotRussianWordException("Text russian word");
            }

            if (receivedString == null)
            {
                throw new ArgumentNullException("Your string is null");
            }

            if (receivedString.Length == 0)
            {
                throw new ArgumentException("Your string is empty");
            }

            this._word = new StringBuilder(receivedString);           
        }
        
        private bool CheckOnRussian(string receivedString)
        {
            return receivedString.All(e => this.Letters.Consonats.Contains(e) || this.Letters.Vowels.Contains(e) || this.Letters.Signs.Contains(e)
                                           || e == '+');
        }

        public int CountOfVowels
        {
            get
            {
                return this.Value.Count(e => this.Letters.Vowels.Contains(e));
            }
        }      

        public void Replace(int indexOldSymbol, char newSymbol)
        {
            this._word[indexOldSymbol] = newSymbol;
        }

        public void Replace(string oldSymbol, string newSymbol)
        {
            this._word.Replace(oldSymbol, newSymbol);
        }

        public void Insert(int indexOfSymbol, string newSymbols)
        {
            this._word.Insert(indexOfSymbol, newSymbols);
        }
        
        public void Remove(char symbol)
        {
            if (this.Value.Contains('+'))
            {
                this._word.Remove(Find(symbol), 1);
            }
        }

        public int Find(char symbol)
        {
            return this._word.ToString().IndexOf(symbol);
        }

        public bool CheckOfBeforeNoConsonat(int index)
        {
            return index == 0 || !this.Letters.Consonats.Contains(_word[index - 1]) ;
        }
    }
}
