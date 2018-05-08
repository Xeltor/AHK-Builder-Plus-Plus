using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus.Programs
{
    internal class OvaleVisualizer
    {
        private Process Visualizer;

        public OvaleVisualizer()
        {
            Visualizer = new Process();
            Visualizer.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Tools", "OvaleVisualizer.exe");
            Visualizer.StartInfo.UseShellExecute = false;
        }

        public void Run(int OvaleXCoordinate, int OvaleYCoordinate, int PixelMainXCoordinate, int PixelMainYCoordinate, int PixelAltXCoordinate, int PixelAltYCoordinate, int OffSet)
        {
            Visualizer.StartInfo.Arguments = $"{OvaleXCoordinate} {OvaleYCoordinate} {PixelMainXCoordinate} {PixelMainYCoordinate} {PixelAltXCoordinate} {PixelAltYCoordinate} {OffSet}";
            Visualizer.Start();
        }

        public bool IsRunning()
        {
            return Process.GetProcessesByName("OvaleVisualizer").Any();
        }

        public void Kill()
        {
            Visualizer = Process.GetProcessesByName("OvaleVisualizer").First();

            Visualizer.Kill();
            Visualizer.WaitForExit();
        }
    }
}
