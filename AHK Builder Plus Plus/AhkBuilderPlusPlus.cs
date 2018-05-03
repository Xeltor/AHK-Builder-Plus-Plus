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

            // Move form to front.
            Activate();
        }

        private void AhkBuilderPlusPlus_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();

            var xml = new XmlFunctions(ahkDataSet);
            xml.ClearBackup();
        }

        private void CoordinateBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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

        private void OvaleScaleBox_Leave(object sender, EventArgs e)
        {
            var sucess = double.TryParse(ovaleScaleBox.Text, out double scale);

            if (!sucess)
            {
                ovaleScaleBox.Text = "1,0";
                return;
            }

            if (scale < 0.5)
                scale = 0.5;
            else if (scale > 3)
                scale = 3;

            ovaleScaleBox.Text = string.Format("{0:0.0}", scale);
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
                MessageBox.Show("Please select a spell before pressing the add button.","Select a spell");
                return;
            }

            // Check if a keybind is set.
            if (string.IsNullOrEmpty(bindingBox.Text))
            {
                MessageBox.Show("Please set a keybind before pressing the add button.", "Set a keybind");
                return;
            }

            var pixelFinder = new PixelFinder(xCoordinateBox.Text, yCoordinateBox.Text, ovaleScaleBox.Text);
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
                MessageBox.Show("A key binding with the same pixel color combination is already present in the table.", "Duplicate value.");
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
            openXML.Filter = "XML Files|*.xml";
            openXML.RestoreDirectory = true;
            openXML.Title = "Load a previously created rotation";
            openXML.Multiselect = false;

            var result = openXML.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var xml = new XmlFunctions(ahkDataSet);
            var loadResult = xml.Load(openXML.FileName);

            if (loadResult)
                MessageBox.Show("Rotation loaded.", "Import completed.");
            else
                MessageBox.Show("Could not load XML file.", "Import failed.");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ahkDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Nothing to save.", "Error");
                return;
            }

            var saveXML = new SaveFileDialog();
            saveXML.Filter = "XML Files|*.xml";
            saveXML.RestoreDirectory = true;
            saveXML.Title = "Select a location to save your rotation.";

            var result = saveXML.ShowDialog();

            if (result != DialogResult.OK)
                return;

            var xml = new XmlFunctions(ahkDataSet);
            var saveResult = xml.Save(saveXML.FileName);

            if (saveResult)
                MessageBox.Show("Rotation saved.", "Export completed.");
            else
                MessageBox.Show("Could not save XML file.", "Export failed.");
        }

        private void generateAhkButton_Click(object sender, EventArgs e)
        {
            var result = GenerateAHK();

            if (result == DialogResult.OK)
                MessageBox.Show("Rotation saved as AHK.", "AHK created.");
        }
    }
}
