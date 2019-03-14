
using System.Linq;


namespace DEV_2
{
    public static class StringExtension
    {
        public static string GetPhoneticRepresentation(this string receivedString)
        {
            return new string(receivedString.Select((e, i) => (e == 'о') && (i == receivedString.Length - 1  || receivedString[i + 1] != '+') ? 'а' : e).ToArray());
        }
    }
}
