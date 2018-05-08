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

        /// <summary>
        /// Returns the X location on screen based on the Ovale offset.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <returns>Integer based X coordinate.</returns>
        public static int ToX(this string s)
        {
            if (!int.TryParse(s, out int XcoordOffset))
                return 0;

            return (Screen.PrimaryScreen.Bounds.Width / 2) + ((XcoordOffset - 3) - 2);
        }

        /// <summary>
        /// Returns the x location on the screen for the center of the Ovale box.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToOvaleX(this string s)
        {
            if (!int.TryParse(s, out int XcoordOffset))
                return 0;

            return (Screen.PrimaryScreen.Bounds.Width / 2) + (XcoordOffset - 3);
        }

        /// <summary>
        /// Returns the Y location on screen based on the Ovale offset.
        /// </summary>
        /// <param name="s">The string to convert.</param>
        /// <param name="main">Setting this to false provides the second Y pixel location on the screen.</param>
        /// <returns>Integer based Y coordinate.</returns>
        public static int ToY(this string s, double ovaleScale, bool main = true)
        {
            if (!int.TryParse(s, out int YcoordOffset))
                return 0;

            var additionalOffset = (main) ? -10 : 10;

            return ((Screen.PrimaryScreen.Bounds.Height / 2) + ((YcoordOffset * -1) + 3)) + (int)(additionalOffset * ovaleScale);
        }

        /// <summary>
        /// Returns the y location on the screen for the center of the Ovale box.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int ToOvaleY(this string s)
        {
            if (!int.TryParse(s, out int YcoordOffset))
                return 0;

            return (Screen.PrimaryScreen.Bounds.Height / 2) + ((YcoordOffset * -1) + 3);
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
