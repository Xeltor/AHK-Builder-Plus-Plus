using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus.Programs
{
    internal class OvaleVisualizer
    {
        private int OvaleX;
        private int OvaleY;
        private int MainX;
        private int MainY;
        private int AltX;
        private int AltY;

        public OvaleVisualizer(int OvaleXCoordinate, int OvaleYCoordinate, int PixelMainXCoordinate, int PixelMainYCoordinate, int PixelAltXCoordinate, int PixelAltYCoordinate)
        {
            OvaleX = OvaleXCoordinate;
            OvaleY = OvaleYCoordinate;
            MainX = PixelMainXCoordinate;
            MainY = PixelMainYCoordinate;
            AltX = PixelAltXCoordinate;
            AltY = PixelAltYCoordinate;
        }

        public void Run()
        {
            var process = new Process();
            process.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Tools", "OvaleVisualizer.exe");
            process.StartInfo.Arguments = $"{OvaleX} {OvaleY} {MainX} {MainY} {AltX} {AltY}";
            process.StartInfo.UseShellExecute = false;
            process.Start();

            MessageBox.Show("Currently displaying a visual representation of the pixel locations, close this window to disable it.", "Visualizer");

            process.Kill();
            process.WaitForExit();
        }
    }
}
