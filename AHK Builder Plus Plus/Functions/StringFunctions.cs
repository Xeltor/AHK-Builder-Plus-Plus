using System;
using System.Windows.Forms;

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

        public static double ToPoint(this string s, double offset, double scale)
        {
            if (!double.TryParse(s, out double position))
                return 0;

            return position + (offset * scale);
        }

        /// <summary>
        /// Divides percentage scale by 100.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Double percentage.</returns>
        public static double ToDouble(this string s)
        {
            if (!double.TryParse(s, out double percentageScale))
                return 0;

            return percentageScale / 100;
        }
    }
}
