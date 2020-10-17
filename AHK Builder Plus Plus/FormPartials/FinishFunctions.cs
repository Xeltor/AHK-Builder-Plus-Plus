using AHK_Builder_Plus_Plus.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        public DialogResult GenerateAHK()
        {
            if (string.IsNullOrEmpty(ahkToggleKeyBox.Text))
            {
                MessageBox.Show("Please set an Ahk toggle key before generating an AHK file.", "Toggle key error");
                return DialogResult.Cancel;
            }

            if (classBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a spec before generating an AHK file.", "Spec error");
                return DialogResult.Cancel;
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
                return DialogResult.Cancel;
            }

            if (ahkDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add keybinds before generating an AHK file.", "Keybind error");
                return DialogResult.Cancel;
            }

            using (SaveFileDialog ahkFileLocation = new SaveFileDialog
            {
                FileName = $"{classBox.SelectedItem.ToString().Replace(" ", "")}.ahk",
                Filter = "AHK Files|*.ahk",
                RestoreDirectory = true,
                Title = "Select a location to save your AHK file."
            })
            {
                var result = ahkFileLocation.ShowDialog();

                if (result != DialogResult.OK)
                    return result;

                try
                {
                    using (var ahkFile = new StreamWriter(ahkFileLocation.FileName, false))
                    {
                        // Top part of the file.
                        ahkFile.WriteLine("#Persistent");
                        ahkFile.WriteLine("Active := False");
                        ahkFile.WriteLine("Tickrate := 1000 / 60");

                        if (ahkToggleKeyBox.Text == "ScrollLock")
                            ahkFile.WriteLine("SetScrollLockState, AlwaysOff");

                        if (ahkToggleKeyBox.Text == "CapsLock")
                            ahkFile.WriteLine("SetCapsLockState, AlwaysOff");

                        ahkFile.WriteLine("");
                        ahkFile.WriteLine($"{ahkToggleKeyBox.Text}::");
                        ahkFile.WriteLine("	SetTimer, Rotation, % (Toggle:=!Toggle) ? Tickrate : \"Off\"");
                        ahkFile.WriteLine("	Active := !Active");
                        ahkFile.WriteLine("");
                        ahkFile.WriteLine("	if (Active) {");
                        ahkFile.WriteLine($"		TrayTip, {classBox.SelectedItem.ToString()}, Rotation activated, 5, 17");
                        ahkFile.WriteLine("	} else {");
                        ahkFile.WriteLine($"		TrayTip, {classBox.SelectedItem.ToString()}, Rotation deactivated, 5, 17");
                        ahkFile.WriteLine("	}");
                        ahkFile.WriteLine("return");
                        ahkFile.WriteLine("");
                        ahkFile.WriteLine("Rotation:");
                        ahkFile.WriteLine("	WinWaitActive, World of Warcraft,");

                        // Get pixel locations.
                        ahkFile.WriteLine($"	PixelGetColor, CLRa, {FirstXCoordinate}, {FirstYCoordinate}");
                        ahkFile.WriteLine($"	PixelGetColor, CLRb, {SecondXCoordinate}, {SecondYCoordinate}");

                        // Generate if chain of doom.
                        var strings = GenerateAhkColorCheck();
                        foreach (var line in strings)
                            ahkFile.WriteLine(line);

                        ahkFile.WriteLine("	}");
                        ahkFile.WriteLine("return");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error while generating the AHK.", "Error.");
                    MessageBox.Show(ex.Message, "Error.");
                    return DialogResult.Abort;
                }

                // Save as XML for later loading purposes.
                var f = new FileInfo(ahkFileLocation.FileName);

                // Create directory if it doesnt exist.
                var d = new DirectoryInfo(Path.Combine(f.DirectoryName, "XML"));
                if (!d.Exists)
                    d.Create();

                // Hide directory from user sight.
                d.Attributes = FileAttributes.Hidden;

                // Save XML.
                var XML = new XmlFunctions(ahkDataSet);
                var XmlFile = Path.ChangeExtension(Path.Combine(d.FullName, f.Name), ".xml");

                XML.Save(XmlFile);

                return result;
            }
        }

        private string[] GenerateAhkColorCheck()
        {
            var strings = new List<string>();

            for (var i = 0; i < AhkTable.Rows.Count-1; i++)
            {
                var row = AhkTable.Rows[i];
                if (i == 0)
                {
                    strings.Add($"	if (CLRa = \"{row.Cells[2].Value}\" and CLRb = \"{row.Cells[3].Value}\") {{ ; {row.Cells[0].Value}");

                    strings.Add($"		Send, {row.Cells[1].Value}");
                }
                else
                {
                    strings.Add($"	}} else if (CLRa = \"{row.Cells[2].Value}\" and CLRb = \"{row.Cells[3].Value}\") {{ ; {row.Cells[0].Value}");

                    strings.Add($"		Send, {row.Cells[1].Value}");
                }
            }

            return strings.ToArray();
        }
    }
}
