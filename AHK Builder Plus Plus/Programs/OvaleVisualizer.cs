using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        private ProcessStartInfo VisualizerStartInfo;

        private Task<string> RunProcessAsync(Process process)
        {
            var tcs = new TaskCompletionSource<string>();

            process.OutputDataReceived += (s, ea) => OutputHandler(ea.Data);

            bool started = process.Start();
            if (!started)
            {
                //you may allow for the process to be re-used (started = false) 
                //but I'm not sure about the guarantees of the Exited event in such a case
                throw new InvalidOperationException("Could not start process: " + process);
            }

            process.BeginOutputReadLine();

            return tcs.Task;
        }

        public void RunVisualizer(double OvaleXCoordinate, double OvaleYCoordinate, double PixelOneHorizontalOffset, double PixelOneVerticalOffset, double PixelTwoHorizontalOffset, double PixelTwoVerticalOffset, double OffSet)
        {

            VisualizerStartInfo = new ProcessStartInfo();
            VisualizerStartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Tools", "OvaleVisualizer.exe");
            VisualizerStartInfo.UseShellExecute = false;
            VisualizerStartInfo.RedirectStandardOutput = true;

            var Visualizer = new Process();
            VisualizerStartInfo.Arguments = $"{OvaleXCoordinate} {OvaleYCoordinate} {PixelOneHorizontalOffset} {PixelOneVerticalOffset} {PixelTwoHorizontalOffset} {PixelTwoVerticalOffset} {OffSet}";
            Visualizer.StartInfo = VisualizerStartInfo;

            Task.Run(() => RunProcessAsync(Visualizer));
        }

        private void OutputHandler(string e)
        {
            if (!string.IsNullOrEmpty(e) && (e.Contains(":")))
            {
                var split = e.Trim(':').Split(':');

                BoxCenterHorizontalPosition.Invoke(new Action(() => BoxCenterHorizontalPosition.Text = split[split.Length-2]));
                BoxCenterVerticalPosition.Invoke(new Action(() => BoxCenterVerticalPosition.Text = split[split.Length-1]));
            }
        }

        public bool IsVisualizerRunning()
        {
            return Process.GetProcessesByName("OvaleVisualizer").Any();
        }

        public void KillVisualizer()
        {
            var Visualizer = Process.GetProcessesByName("OvaleVisualizer").First();

            Visualizer.Kill();
            Visualizer.WaitForExit();
        }
    }

    public class BoxLocation
    {
        public double Horizontal { get; private set; }
        public double Vertical { get; private set; }

        public BoxLocation(string output)
        {
            var split = output.Split(':');

            Horizontal = double.Parse(split[0]);
            Vertical = double.Parse(split[1]);
        }
    }
}
