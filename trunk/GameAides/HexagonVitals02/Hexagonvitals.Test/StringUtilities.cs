namespace Hexagonvitals.Test
{
    public static class StringUtilities
    {
        public static string FormatWith(this string formatText, params object[] options)
        {
            return string.Format(formatText, options);
        }
    }
}