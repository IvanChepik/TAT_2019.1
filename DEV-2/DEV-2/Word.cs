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
        private StringBuilder word;
        public Letters letters = new Letters();
        
        public Word(string receivedString)
        {
            if(!CheckOnRussian(receivedString))
            {
                throw new ArgumentException("Text russian word");
            }
            word = new StringBuilder(receivedString);           
        }

        private bool CheckOnRussian(string receivedString)
        {
            return receivedString.All(e => letters.consonats.Contains(e) || letters.vowels.Contains(e));
        }
        public int CountOfVowels
        {
            get
            {
                return Value.Count(e => letters.vowels.Contains(e));
            }
        }
        public string Value
        {
            get
            {
                return word.ToString();
            }
        }
        public int Length
        {
            get
            {
                return Value.Length;
            }
        }
        public void Replace(int indexOldSymbol, char newSymbol)
        {
            word[indexOldSymbol] = newSymbol;
        }
        public void Replace(string oldSymbol, string newSymbol)
        {
            word.Replace(oldSymbol, newSymbol);
        }
        public void Insert(int indexOfSymbol, string newSymbols)
        {
            word.Insert(indexOfSymbol, newSymbols);
        }
        
        public void Remove(char symbol)
        {
            if (Value.Contains('+'))
            {
                word.Remove(Find(symbol), 1);
            }
        }
        public int Find(char symbol)
        {
            return word.ToString().IndexOf(symbol);
        }
        public bool CheckOfBeforeNoConsonat(int index)
        {
            return index == 0 || !letters.consonats.Contains(word[index - 1]) ;
        }
    }
}
