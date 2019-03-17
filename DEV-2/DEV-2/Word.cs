using System.Text;
using System.Linq;

namespace DEV_2
{
    public class Word
    {
        private StringBuilder word;
        private Letters letters = new Letters();
        
        public Word(string receivedString)
        {
            word = new StringBuilder(receivedString);
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
        public void Insert(int indexOfSymbol, string newSymbols)
        {
            word.Insert(indexOfSymbol, newSymbols);
        }

        public bool CheckOfBeforeNoConsonat(int index)
        {
            return index == 0 || !letters.consonats.Contains(word[index - 1]);
        }
    }
}
