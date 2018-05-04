using AHK_Builder_Plus_Plus.Objects;
using System;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus.Functions
{
    internal static class KeyboardFunctions
    {
        /// <summary>
        /// Takes the current pressed key and converts it to AHK supported code.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="Modifier">Process Control, Shift and Alt.</param>
        /// <param name="Braceless">Add braces when needed.</param>
        /// <returns></returns>
        public static string ToAhk(this KeyEventArgs e, bool CheckModifiers = true, bool Braceless = false)
        {
            string key = null;
            
            // Alphabetic keys
            if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
            {
                key = e.KeyCode.ToString().ToLowerInvariant();
            }

            // Numeric
            else if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
            {
                key = e.KeyCode.ToString().Replace("D", "");
            }

            // Numeric numpad or Function keys.
            else if ((e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) || (e.KeyCode >= Keys.F1 && e.KeyCode <= Keys.F24))
            {
                var cleanKey = e.KeyCode.ToString().Replace("P", "p");

                if (Braceless)
                    key = cleanKey;
                else
                    key = "{" + cleanKey + "}";
            }

            // Caps lock
            else if (e.KeyCode == Keys.CapsLock && !CheckModifiers)
            {
                if (Braceless)
                    key = "CapsLock";
                else
                    key = "{CapsLock}";
            }

            // Scroll lock
            else if (e.KeyCode == Keys.Scroll && !CheckModifiers)
            {
                if (Braceless)
                    key = "ScrollLock";
                else
                    key = "{ScrollLock}";
            }

            // Other Oem keys.
            else
                switch (e.KeyCode)
                {
                    case Keys.Oemplus:
                        key = "=";
                        break;
                    case Keys.Subtract:
                    case Keys.OemMinus:
                        key = "-";
                        break;
                    case Keys.Oemtilde:
                        key = "`";
                        break;
                    case Keys.OemBackslash:
                        key = @"\";
                        break;
                    case Keys.Decimal:
                    case Keys.OemPeriod:
                        key = ".";
                        break;
                    case Keys.OemPipe:
                        key = "|";
                        break;
                    case Keys.Oem2:
                    case Keys.Divide:
                        key = "/";
                        break;
                    case Keys.Multiply:
                        key = "*";
                        break;
                    case Keys.Add:
                        key = "+";
                        break;
                    default:
                        return null;
                }
            
            // Process modifiers.
            Modifiers mods = ProcessModifiers(e);

            // Output final conversion.
            if (!CheckModifiers)
                return key;
            else
                return mods.Start + key + mods.End;
        }

        private static Modifiers ProcessModifiers(KeyEventArgs e)
        {
            var mods = new Modifiers();

            if (e.Control)
            {
                mods.Start += @"{CTRLDOWN}";
                mods.End = @"{CTRLUP}" + mods.End;
            }

            if (e.Shift)
            {
                mods.Start += @"{SHIFTDOWN}";
                mods.End = @"{SHIFTUP}" + mods.End;
            }

            if (e.Alt)
            {
                mods.Start += @"{ALTDOWN}";
                mods.End = @"{ALTUP}" + mods.End;
            }

            return mods;
        }
    }
}