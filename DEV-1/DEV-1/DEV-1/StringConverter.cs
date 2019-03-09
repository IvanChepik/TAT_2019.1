using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DEV_1
{
    public class StringConverter
    {
        /// <summary>
        /// Method GetAllUniqueSequences
        /// searches for the all sequence with serial unique symbols in string.
        /// </summary>
        /// <param name="receivedString">String, which was inputed</param>
        /// <returns>Collection of all sequence with unique serial symbols</returns>
        public IEnumerable<string> GetAllUniqueSequences(string receivedString)
        {
            var maxUniqueSequence = new StringBuilder();
            var allMaxSequence = new List<string>();
            //Find all max length sequence with unique serial symbols and add it to maxUniqueSequence 
            for (var index = 0; index < receivedString.Length; index++)
            {
                maxUniqueSequence.Append(receivedString[index]);
                if (receivedString.Length == index + 1 || receivedString[index] == receivedString[index + 1])
                {
                    if (maxUniqueSequence.Length > 1)
                    {
                        allMaxSequence.Add(maxUniqueSequence.ToString());
                    }
                    maxUniqueSequence.Clear();
                }
            } 
            return GetAllSubstrings(allMaxSequence);         
        }

        /// <summary>
        /// Method GetAllSubstrings
        /// searches for all substring of max length sequences
        /// </summary>
        /// <param name="maxSequences">Collection of max sequences with unique serial symbolf of string</param>
        /// <returns>All sequences with unique serial symbols</returns>
        public IEnumerable<string> GetAllSubstrings(IEnumerable<string> maxSequences)
        {
            //Iterating every max length sequences for all serial sequences and add it to collection
            var allSequences = new List<string>();
            foreach (var sequence in maxSequences)
            {
                for (var i = 0; i < sequence.Length; i++)
                {
                    for (var j = i+1; j < sequence.Length; j++)
                    {
                        var substring = new string(sequence.Skip(i).Take(j-i+1).ToArray());
                        if(substring.Length > 1)
                        {
                            allSequences.Add(substring);
                        }
                    }
                }
            }
            return allSequences;
        }
    }   
}
