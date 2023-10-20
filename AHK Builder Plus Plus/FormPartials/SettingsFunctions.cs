using System;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        internal void InitSettings()
        {
            Properties.Settings.Default.Save();
        }

        internal void SaveSettings()
        {
            Properties.Settings.Default.BoxCenterHorizontalPosition = BoxCenterHorizontalPosition.Text;
            Properties.Settings.Default.BoxCenterVerticalPosition = BoxCenterVerticalPosition.Text;
            Properties.Settings.Default.BoxSizeInPixels = BoxSizeInPixels.Text;
            Properties.Settings.Default.ahkToggleKey = ahkToggleKeyBox.Text;

            Properties.Settings.Default.Save();
        }

        internal void LoadSettings()
        {
            BoxCenterHorizontalPosition.Text = Properties.Settings.Default.BoxCenterHorizontalPosition;
            BoxCenterVerticalPosition.Text = Properties.Settings.Default.BoxCenterVerticalPosition;
            BoxSizeInPixels.Text = Properties.Settings.Default.BoxSizeInPixels;
            ahkToggleKeyBox.Text = Properties.Settings.Default.ahkToggleKey;
        }
    }
}