namespace AHK_Builder_Plus_Plus.Functions
{
    public static class StringFunctions
    {
        public static string FirstCap(this string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
