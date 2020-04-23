using System;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        internal void InitSettings()
        {
            retry:
            var result = wowBrowserDialog.ShowDialog();

            if (result != DialogResult.OK)
                Environment.Exit(42);

            if (!File.Exists(Path.Combine(wowBrowserDialog.SelectedPath, @"Wow.exe")))
                goto retry;

            Properties.Settings.Default.wowLocation = wowBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
        }

        internal void SaveSettings()
        {
            Properties.Settings.Default.xCoordinateOffset = xOffsetBox.Text;
            Properties.Settings.Default.yCoordinateOffset = yOffsetBox.Text;
            Properties.Settings.Default.ovaleScale = ovaleScaleBox.Text;
            Properties.Settings.Default.ahkToggleKey = ahkToggleKeyBox.Text;

            Properties.Settings.Default.Save();
        }

        internal void LoadSettings()
        {
            xOffsetBox.Text = Properties.Settings.Default.xCoordinateOffset;
            yOffsetBox.Text = Properties.Settings.Default.yCoordinateOffset;
            ovaleScaleBox.Text = Properties.Settings.Default.ovaleScale;
            ahkToggleKeyBox.Text = Properties.Settings.Default.ahkToggleKey;
        }
    }
}