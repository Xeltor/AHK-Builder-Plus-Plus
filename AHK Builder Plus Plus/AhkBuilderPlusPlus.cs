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
            // Load settings.
            LoadSettings();
            LoadClassList();

            // Load previous session (if exists)
            var xml = new XmlFunctions(ahkDataSet);
            xml.Load();

            // Check if visualizer was still running from previous crash.
            if (IsVisualizerRunning())
                KillVisualizer();

            // Move form to front.
            Activate();

            // First time setup?
            if (
                BoxCenterHorizontalPosition.Text == "0" || 
                BoxCenterVerticalPosition.Text == "0" || 
                string.IsNullOrEmpty(ahkToggleKeyBox.Text)
                )
            {
                tabControl1.SelectTab(1);
            }
        }

        private void AhkBuilderPlusPlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save settings.
            SaveSettings();

            // Clean temp backup file.
            var xml = new XmlFunctions(ahkDataSet);
            xml.ClearBackup();

            // Check if visualizer is still running.
            if (IsVisualizerRunning())
                KillVisualizer();
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

            // Check if coordinates are good.
            var Scale = double.Parse(BoxSizeInPixels.Text) / 50; // 50 is the default pixel size for Hekili
            var FirstXCoordinate = BoxCenterHorizontalPosition.Text.ToPoint(-5, Scale);
            var FirstYCoordinate = BoxCenterVerticalPosition.Text.ToPoint(-12, Scale);
            var SecondXCoordinate = BoxCenterHorizontalPosition.Text.ToPoint(-5, Scale);
            var SecondYCoordinate = BoxCenterVerticalPosition.Text.ToPoint(12, Scale);
            if (FirstXCoordinate <= 0 || FirstXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || FirstYCoordinate <= 0 || FirstYCoordinate > Screen.PrimaryScreen.Bounds.Height
                || SecondXCoordinate <= 0 || SecondXCoordinate > Screen.PrimaryScreen.Bounds.Width
                || SecondYCoordinate <= 0 || SecondYCoordinate > Screen.PrimaryScreen.Bounds.Height)
            {
                MessageBox.Show("Please make sure the X and Y offsets are correct, currently returns an offscreen coordinate.", "Offset error.");
                return;
            }

            // Turn off visualizer if its still on.
            if (IsVisualizerRunning())
                KillVisualizer();

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
            using (OpenFileDialog openXML = new OpenFileDialog
            {
                Filter = "AHK Files|*.ahk",
                RestoreDirectory = true,
                Title = "Load a previously created rotation",
                Multiselect = false
            })
            {
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
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GenerateAhkButton_Click(object sender, EventArgs e)
        {
            var result = GenerateAHK();

            if (result == DialogResult.OK)
                MessageBox.Show("Rotation saved as AHK.", "AHK created.");
        }

        private void VisualizerButton_Click(object sender, EventArgs e)
        {
            // Check if coordinates are good.
            var boxSize = double.Parse(BoxSizeInPixels.Text);
            var Scale = boxSize / 50; // 50 is the default pixel size for Hekili
            var OvaleXCoordinate = BoxCenterHorizontalPosition.Text.ToPoint(0, Scale);
            var OvaleYCoordinate = BoxCenterVerticalPosition.Text.ToPoint(0, Scale);
            var FirstHorizontalOffset = -5 * Scale;
            var FirstVerticalOffset = -12 * Scale;
            var SecondHorizontalOffset = -5 * Scale;
            var SecondVerticalOffset = 12 * Scale;

            //var config = new WoWConfig();
            var offSet = boxSize / 2;

            if (!IsVisualizerRunning())
                RunVisualizer(OvaleXCoordinate, OvaleYCoordinate, FirstHorizontalOffset, FirstVerticalOffset, SecondHorizontalOffset, SecondVerticalOffset, offSet);
            else
                KillVisualizer();
        }

        private void HelpTip_MouseEnter(object sender, EventArgs e)
        {
            helpTip.SetToolTip(visualizerButton, "Shows a cross and 2 dots to visualize where the builder is getting pixelcolor 1 & 2.");
        }

        private void currentTier_Leave(object sender, EventArgs e)
        {
            LoadClassList();
        }
    }
}
