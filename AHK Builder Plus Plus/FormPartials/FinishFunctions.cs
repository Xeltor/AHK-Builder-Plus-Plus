﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        public DialogResult GenerateAHK()
        {
            if (ahkDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add keybinds before generating an AHK file.", "Error");
                return DialogResult.Cancel;
            }

            var ahkFileLocation = new SaveFileDialog();
            ahkFileLocation.Filter = "AHK Files|*.ahk";
            ahkFileLocation.RestoreDirectory = true;
            ahkFileLocation.Title = "Select a location to save your AHK file.";

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

                    if (ahkToggleKeyBox.Text == "ScrollLock")
                        ahkFile.WriteLine("SetScrollLockState, AlwaysOff");

                    if (ahkToggleKeyBox.Text == "CapsLock")
                        ahkFile.WriteLine("SetScrollLockState, AlwaysOff");

                    ahkFile.WriteLine("");
                    ahkFile.WriteLine($"{ahkToggleKeyBox.Text}::");
                    ahkFile.WriteLine("	SetTimer, Rotation, % (Toggle:=!Toggle) ? 32 : \"Off\"");
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
                    var pixelfinder = new Programs.PixelFinder(xOffsetBox.Text, yOffsetBox.Text, ovaleScaleBox.Text);
                    ahkFile.WriteLine($"	PixelGetColor, CLRa, {xOffsetBox.Text}, {yOffsetBox.Text}");
                    ahkFile.WriteLine($"	PixelGetColor, CLRb, {pixelfinder.xCoordinateAlt}, {pixelfinder.yCoordinateAlt}");

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

            return result;
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