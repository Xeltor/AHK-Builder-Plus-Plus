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
                MessageBox.Show("Please select a class before generating an AHK file.", "Class error");
                return DialogResult.Cancel;
            }

            // Check if scale box is set properly.
            var scale = ovaleScaleBox.Text.ToDouble();
            if (scale < 0.5 || scale > 3)
            {
                MessageBox.Show("Please set an Ovale Scale % between 50 and 300", "Ovale scale error");
                return DialogResult.Cancel;
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
                return DialogResult.Cancel;
            }

            if (ahkDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add keybinds before generating an AHK file.", "Keybind error");
                return DialogResult.Cancel;
            }

            using (SaveFileDialog ahkFileLocation = new SaveFileDialog
            {
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
                        if (AltMatching.Checked)
                        {
                            ahkFile.WriteLine($"	PixelGetColor, CLRa, {FirstXCoordinate}, {FirstYCoordinate}, Alt");
                            ahkFile.WriteLine($"	PixelGetColor, CLRb, {SecondXCoordinate}, {SecondYCoordinate}, Alt");
                        }
                        else if (SlowMatching.Checked)
                        {
                            ahkFile.WriteLine($"	PixelGetColor, CLRa, {FirstXCoordinate}, {FirstYCoordinate}, Slow");
                            ahkFile.WriteLine($"	PixelGetColor, CLRb, {SecondXCoordinate}, {SecondYCoordinate}, Slow");
                        }
                        else
                        {
                            ahkFile.WriteLine($"	PixelGetColor, CLRa, {FirstXCoordinate}, {FirstYCoordinate}");
                            ahkFile.WriteLine($"	PixelGetColor, CLRb, {SecondXCoordinate}, {SecondYCoordinate}");
                        }

                        // Generate if chain of doom.
                        int fuzzy = 0;
                        if (FuzzyColorOne.Checked)
                            fuzzy = 1;
                        else if (FuzzyColorTwo.Checked)
                            fuzzy = 2;

                        var strings = GenerateAhkColorCheck(fuzzy);
                        foreach (var line in strings)
                            ahkFile.WriteLine(line);

                        ahkFile.WriteLine("	}");
                        ahkFile.WriteLine("return");

                        if (FuzzyColorOne.Checked || FuzzyColorTwo.Checked)
                        {
                            ahkFile.WriteLine("");
                            ahkFile.WriteLine("Compare(color1, color2, vary=20) {");
                            ahkFile.WriteLine("	c1 := ToRGB(color1)");
                            ahkFile.WriteLine("	c2 := ToRGB(color2)");
                            ahkFile.WriteLine("");
                            ahkFile.WriteLine("	rdiff := Abs( c1.r - c2.r )");
                            ahkFile.WriteLine("	gdiff := Abs( c1.g - c2.g )");
                            ahkFile.WriteLine("	bdiff := Abs( c1.b - c2.b )");
                            ahkFile.WriteLine("");
                            ahkFile.WriteLine("	return rdiff <= vary && gdiff <= vary && bdiff <= vary");
                            ahkFile.WriteLine("}");
                            ahkFile.WriteLine("");
                            ahkFile.WriteLine("ToRGB(color) {");
                            ahkFile.WriteLine("	return { \"r\": (color >> 16) & 0xFF, \"g\": (color >> 8) & 0xFF, \"b\": color & 0xFF }");
                            ahkFile.WriteLine("}");
                        }
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

        private string[] GenerateAhkColorCheck(int Fuzzy = 0)
        {
            var strings = new List<string>();

            for (var i = 0; i < AhkTable.Rows.Count-1; i++)
            {
                var row = AhkTable.Rows[i];
                if (i == 0)
                {
                    if (Fuzzy == 1)
                        strings.Add($"	if (Compare(\"{row.Cells[2].Value}\", CLRa) and CLRb = \"{row.Cells[3].Value}\") {{ ; {row.Cells[0].Value}");
                    else if (Fuzzy == 2)
                        strings.Add($"	if (CLRa = \"{row.Cells[2].Value}\" and Compare(\"{row.Cells[3].Value}\", CLRb)) {{ ; {row.Cells[0].Value}");
                    else
                        strings.Add($"	if (CLRa = \"{row.Cells[2].Value}\" and CLRb = \"{row.Cells[3].Value}\") {{ ; {row.Cells[0].Value}");

                    strings.Add($"		Send, {row.Cells[1].Value}");
                }
                else
                {

                    if (Fuzzy == 1)
                        strings.Add($"	}} else if (Compare(\"{row.Cells[2].Value}\", CLRa) and CLRb = \"{row.Cells[3].Value}\") {{ ; {row.Cells[0].Value}");
                    else if (Fuzzy == 2)
                        strings.Add($"	}} else if (CLRa = \"{row.Cells[2].Value}\" and Compare(\"{row.Cells[3].Value}\", CLRb)) {{ ; {row.Cells[0].Value}");
                    else
                        strings.Add($"	}} else if (CLRa = \"{row.Cells[2].Value}\" and CLRb = \"{row.Cells[3].Value}\") {{ ; {row.Cells[0].Value}");

                    strings.Add($"		Send, {row.Cells[1].Value}");
                }
            }

            return strings.ToArray();
        }
    }
}
