using System.Collections.Generic;
using System.Linq;


namespace DEV_2
{
    public static class StringExtension
    {
        public static string GetPhoneticRepresentation(this string receivedString)
        {
            receivedString = ReplaceOSymbolsWithouAccent(receivedString);
            receivedString = ReplaceSonantAndSharp(receivedString);
            return receivedString;
        }

        private static string ReplaceOSymbolsWithouAccent(string receivedString)
        {
            return new string(receivedString
                            .Select((e, i) => (e == 'о') && (i == receivedString.Length - 1 || receivedString[i + 1] != '+') ? 'а' : e)
                            .Where(e=>e!='+')
                            .ToArray());
        }

        private static string ReplaceSonantAndSharp(string receivedString)
        {
            Dictionary<char, char> phoneticConsonats = new Dictionary<char, char>()
            {
                ['б'] = 'п',
                ['в'] = 'ф',
                ['д'] = 'т',
                ['з'] = 'с',
                ['ж'] = 'ш',
                ['г'] = 'к',
            };
            return new string(receivedString
                            .Select((e, i) => phoneticConsonats.ContainsKey(e) && (i == receivedString.Length - 1 || phoneticConsonats.ContainsValue(receivedString[i + 1])) ? phoneticConsonats[e] : e).ToArray());
        }
    }
}
