using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DEV_1
{
    public class StringConverter
    {
        public IEnumerable<string> GetAllUniqueSequences(string receivedString)
        {
            var maxUniqueSequence = new StringBuilder();
            var allMaxSequence = new List<string>();
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

        public IEnumerable<string> GetAllSubstrings(IEnumerable<string> maxSequences)
        {
            var allSequences = new List<string>();
            foreach (var value in maxSequences)
            {
                for (var i = 0; i < value.Length; i++)
                {
                    for (var j = i+1; j < value.Length; j++)
                    {
                        var substring = new string(value.Skip(i).Take(j-i+1).ToArray());
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
