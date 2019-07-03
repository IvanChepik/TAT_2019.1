using System;

namespace Materials
{
    /// <summary>
    /// class StringExtenstion
    /// translate guid into string
    /// </summary>
    public static class StringExtenstion
    {
        public static string GetId(this string id)
        {
            return Guid.NewGuid().ToString();
        }
    }
}