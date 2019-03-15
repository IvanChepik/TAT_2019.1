using System.Linq;

namespace DEV_2
{
    class PhoneticConverter
    {
        public string GetPhoneticRepresentation(string receivedString)
        {
            receivedString = ReplaceOSymbolsWithouAccent(receivedString);
            return receivedString;
        }
        private string ReplaceOSymbolsWithouAccent(string receivedString)
        {
            return new string(receivedString
                            .Select((e, i) => (e == 'о') && (i == receivedString.Length - 1 || receivedString[i + 1] != '+') ? 'а' : e)
                            .Where(e => e != '+')
                            .ToArray());
        }
    }
}
