using System.Collections.Generic;
using System.Text;

namespace DEV_1
{
    public class StringConverter
    {
        public List<string> GetMaxUniqueSequences(string receivedString)
        {
            StringBuilder maxUniqueSequence = new StringBuilder();
            List<string> allMaxSequence = new List<string>();
            for (int i = 0; i < receivedString.Length - 1; i++)
            {
                maxUniqueSequence.Append(receivedString[i]);
                if (receivedString[i] == receivedString[i + 1])
                {
                    allMaxSequence.Add(maxUniqueSequence.ToString());
                    maxUniqueSequence.Clear();
                }
            }
            if (maxUniqueSequence.Length != 0)
            {
                maxUniqueSequence.Append(receivedString[receivedString.Length - 1]);
                allMaxSequence.Add(maxUniqueSequence.ToString());
            }
            allMaxSequence.RemoveAll(s => s.Length == 1);
            return allMaxSequence;
        }
    }
}
