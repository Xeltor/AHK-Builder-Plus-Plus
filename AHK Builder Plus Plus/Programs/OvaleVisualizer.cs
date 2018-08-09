using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus.Programs
{
    internal class OvaleVisualizer
    {
        private ProcessStartInfo VisualizerStartInfo;

        public OvaleVisualizer()
        {
            VisualizerStartInfo = new ProcessStartInfo();
            VisualizerStartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Tools", "OvaleVisualizer.exe");
            VisualizerStartInfo.UseShellExecute = false;
        }

        public void Run(int OvaleXCoordinate, int OvaleYCoordinate, int PixelMainXCoordinate, int PixelMainYCoordinate, int PixelAltXCoordinate, int PixelAltYCoordinate, int OffSet)
        {
            var Visualizer = new Process();
            VisualizerStartInfo.Arguments = $"{OvaleXCoordinate} {OvaleYCoordinate} {PixelMainXCoordinate} {PixelMainYCoordinate} {PixelAltXCoordinate} {PixelAltYCoordinate} {OffSet}";

            Visualizer.StartInfo = VisualizerStartInfo;
            Visualizer.Start();
        }

        public bool IsRunning()
        {
            return Process.GetProcessesByName("OvaleVisualizer").Any();
        }

        public void Kill()
        {
            var Visualizer = Process.GetProcessesByName("OvaleVisualizer").First();

            Visualizer.Kill();
            Visualizer.WaitForExit();
        }
    }
}
