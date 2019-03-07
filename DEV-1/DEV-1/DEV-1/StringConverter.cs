using System.Collections.Generic;
using System.Text;

namespace DEV_1
{
    public class StringConverter
    {
        public IEnumerable<string> GetMaxUniqueSequences(string receivedString)
        {
            var maxUniqueSequence = new StringBuilder();
            var allMaxSequence = new List<string>();
            for (var index = 0; index < receivedString.Length; index++)
            {
                maxUniqueSequence.Append(receivedString[index]);
                if ((receivedString.Length == index+1 || receivedString[index] == receivedString[index + 1]) &&
                    maxUniqueSequence.Length > 1) 
                {
                    allMaxSequence.Add(maxUniqueSequence.ToString());
                    maxUniqueSequence.Clear();
                }
            }
            
            return allMaxSequence;
        }
    }
}
