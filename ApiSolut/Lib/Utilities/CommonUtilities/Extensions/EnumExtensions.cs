using System;

namespace CommonUtilities.Extensions
{
    public static class EnumExtensions
    {
        public static string ToLowerString(this Enum @enum)
        {
            return @enum.ToString().ToLower();
        }
    }
}