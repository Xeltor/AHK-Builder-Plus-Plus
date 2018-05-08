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
                goto retry;

            if (!File.Exists(Path.Combine(wowBrowserDialog.SelectedPath, @"Wow.exe")))
                goto retry;

            Properties.Settings.Default.wowLocation = wowBrowserDialog.SelectedPath;
            Properties.Settings.Default.Save();
        }

        internal void LockSettings(bool save = true)
        {
            if (save)
                Properties.Settings.Default.settingsLock = !Properties.Settings.Default.settingsLock;

            foreach (Control ctrl in settingBox.Controls)
                if (!ctrl.Name.Contains("label"))
                    ctrl.Enabled = !Properties.Settings.Default.settingsLock;

            lockSettingsButton.Enabled = true;
            if (Properties.Settings.Default.settingsLock)
                lockSettingsButton.Text = "Unlock";
            else
                lockSettingsButton.Text = "Lock";
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
            
            LockSettings(false);
        }
    }
}