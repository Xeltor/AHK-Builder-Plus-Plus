using AHK_Builder_Plus_Plus.Functions;
using AHK_Builder_Plus_Plus.Programs;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus : Form
    {
        public AhkBuilderPlusPlus() : base()
        {
            InitializeComponent();
        }

        private void AhkBuilderPlusPlus_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.wowLocation) || (!File.Exists(Path.Combine(Properties.Settings.Default.wowLocation, @"Wow.exe"))))
                InitSettings();

            // Load settings.
            LoadSettings();
            LoadClassList();

            // Load previous session (if exists)
            var xml = new XmlFunctions(ahkDataSet);
            xml.Load();

            // Check if visualizer was still running from previous crash.
            var visualizer = new OvaleVisualizer();
            if (visualizer.IsRunning())
                visualizer.Kill();

            // Move form to front.
            Activate();
        }

        private void AhkBuilderPlusPlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save settings.
            SaveSettings();

            // Clean temp backup file.
            var xml = new XmlFunctions(ahkDataSet);
            xml.ClearBackup();

            // Check if visualizer is still running.
            var visualizer = new OvaleVisualizer();
            if (visualizer.IsRunning())
                visualizer.Kill();
        }

        private void CoordinateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void AhkToggleKeyBox_KeyDown(object sender, KeyEventArgs e)
        {
            var ahkKey = e.ToAhk(false,true);

            if (!string.IsNullOrEmpty(ahkKey))
                ahkToggleKeyBox.Text = ahkKey;
        }

        private void OvaleScaleBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void OvaleScaleBox_Leave(object sender, EventArgs e)
        {
            var sucess = int.TryParse(ovaleScaleBox.Text, out int scale);

            if (!sucess)
            {
                ovaleScaleBox.Text = "100";
                return;
            }

            if (scale < 50)
                scale = 50;
            else if (scale > 300)
                scale = 300;

            ovaleScaleBox.Text = scale.ToString();
        }

        private void LockSettingsButton_Click(object sender, EventArgs e)
        {
            LockSettings();
            SaveSettings();
        }

        private void ClassBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSpells(classBox.SelectedItem.ToString());
        }

        private void BindingBox_KeyDown(object sender, KeyEventArgs e)
        {
            var ahkBind = e.ToAhk();

            if (!string.IsNullOrEmpty(ahkBind))
                bindingBox.Text = ahkBind;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Check if a spell is selected.
            if (spellBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a spell before pressing the add button.","Spell error");
                return;
            }

            // Check if a keybind is set.
            if (string.IsNullOrEmpty(bindingBox.Text))
            {
                MessageBox.Show("Please set a keybind before pressing the add button.", "Keybind error");
                return;
            }

            // Check if scale box is set properly.
            var scale = ovaleScaleBox.Text.ToDouble();
            if (scale < 0.5 || scale > 3)
            {
                MessageBox.Show("Please set an Ovale Scale % between 50 and 300", "Ovale scale error");
                return;
            }

            // Check if coordinates are good.
            var FirstXCoordinate = xOffsetBox.Text.ToX();
            var FirstYCoordinate = yOffsetBox.Text.ToY(scale);
            var SecondXCoordinate = xOffsetBox.Text.ToX();
            var SecondYCoordinate = yOffsetBox.Text.ToY(scale, false);
            if (FirstXCoordinate <= 0 || FirstXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || FirstYCoordinate <= 0 || FirstYCoordinate > Screen.PrimaryScreen.Bounds.Height
                || SecondXCoordinate <= 0 || SecondXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || SecondYCoordinate <= 0 || SecondYCoordinate > Screen.PrimaryScreen.Bounds.Height)
            {
                MessageBox.Show("Please make sure the X and Y offsets are correct, currently returns an offscreen coordinate.", "Offset error.");
                return;
            }

            // Turn off visualizer if its still on.
            var visualizer = new OvaleVisualizer();
            if (visualizer.IsRunning())
                visualizer.Kill();

            // Run pixelfinder.
            var pixelFinder = new PixelFinder(FirstXCoordinate, FirstYCoordinate, SecondXCoordinate, SecondYCoordinate);
            pixelFinder.Run();

            try
            {
                // Add to table.
                ahkDataTable.Rows.Add(new Object[] { spellBox.SelectedItem.ToString(), bindingBox.Text, pixelFinder.pixelColors.Color1, pixelFinder.pixelColors.Color2 });

                // Make tmp save.
                var xml = new XmlFunctions(ahkDataSet);
                xml.Save();
            }
            catch (ConstraintException)
            {
                MessageBox.Show("A key binding with the same pixel color combination is already present in the table.", "Duplicate color combination error.");
                Activate();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't add keybind because: {ex.Message}", "Error.");
                Activate();
                return;
            }
            
            // Clear current keybind.
            bindingBox.Clear();

            // Roll to caret
            AhkTable.FirstDisplayedScrollingRowIndex = AhkTable.RowCount - 1;

            // Activate main form again.
            Activate();
            }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            var openXML = new OpenFileDialog();
            openXML.Filter = "AHK Files|*.ahk";
            openXML.RestoreDirectory = true;
            openXML.Title = "Load a previously created rotation";
            openXML.Multiselect = false;

            var result = openXML.ShowDialog();

            if (result != DialogResult.OK)
                return;

            // Convert location to XML folder location.
            var f = new FileInfo(openXML.FileName);
            var XmlFile = Path.ChangeExtension(Path.Combine(f.DirectoryName, "XML", f.Name), ".xml");

            // Load XML file.
            var xml = new XmlFunctions(ahkDataSet);
            var loadResult = xml.Load(XmlFile);

            if (loadResult)
                MessageBox.Show("Rotation loaded.", "Import completed.");
            else
                MessageBox.Show("Could not load XML file.", "Import failed.");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void generateAhkButton_Click(object sender, EventArgs e)
        {
            var result = GenerateAHK();

            if (result == DialogResult.OK)
                MessageBox.Show("Rotation saved as AHK.", "AHK created.");
        }

        private void visualizerButton_Click(object sender, EventArgs e)
        {
            // Check if scale box is set properly.
            var scale = ovaleScaleBox.Text.ToDouble();
            if (scale < 0.5 || scale > 3)
            {
                MessageBox.Show("Please set an Ovale Scale % between 50 and 300", "Ovale scale error");
                return;
            }

            // Check if coordinates are good.
            var OvaleXCoordinate = xOffsetBox.Text.ToOvaleX();
            var OvaleYCoordinate = yOffsetBox.Text.ToOvaleY();
            var FirstXCoordinate = xOffsetBox.Text.ToX();
            var FirstYCoordinate = yOffsetBox.Text.ToY(scale);
            var SecondXCoordinate = xOffsetBox.Text.ToX();
            var SecondYCoordinate = yOffsetBox.Text.ToY(scale, false);
            if (FirstXCoordinate <= 0 || FirstXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || FirstYCoordinate <= 0 || FirstYCoordinate > Screen.PrimaryScreen.Bounds.Height
                || SecondXCoordinate <= 0 || SecondXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || SecondYCoordinate <= 0 || SecondYCoordinate > Screen.PrimaryScreen.Bounds.Height
                || OvaleXCoordinate <= 0 || OvaleXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || OvaleYCoordinate <= 0 || OvaleYCoordinate > Screen.PrimaryScreen.Bounds.Height)
            {
                MessageBox.Show("Please make sure the X and Y offsets are correct, currently returns an offscreen coordinate.", "Offset error.");
                return;
            }

            var visualizer = new OvaleVisualizer();
            
            var config = new WoWConfig();
            var offSet = 20;

            if (config.IsUiScaleEnabled())
                offSet = (int)(config.Scaler() * offSet);

            if (!visualizer.IsRunning())
                visualizer.Run(OvaleXCoordinate, OvaleYCoordinate, FirstXCoordinate, FirstYCoordinate, SecondXCoordinate, SecondYCoordinate, offSet);
            else
                visualizer.Kill();
        }

        private void HelpTip_MouseEnter(object sender, EventArgs e)
        {
            helpTip.SetToolTip(xOffsetBox, "You can find this in WoW by typing /ovale config in the chat.");
            helpTip.SetToolTip(yOffsetBox, "You can find this in WoW by typing /ovale config in the chat.");
            helpTip.SetToolTip(ovaleScaleBox, "You can find this in WoW by typing /ovale config in the chat.");
            helpTip.SetToolTip(visualizerButton, "Shows a red cross and 2 red dots to visualize where the builder is getting color 1 & 2.");
        }
    }
}
