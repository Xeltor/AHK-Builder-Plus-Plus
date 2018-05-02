using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus.Programs
{
    internal class PixelFinder
    {
        private string xCoordinateMain;
        private string yCoordinateMain;
        private string ovaleScale;

        public string xCoordinateAlt { get; private set; }
        public string yCoordinateAlt { get; private set; }

        public PixelColors pixelColors { get; private set; }

        public PixelFinder(string xCoordinate, string yCoordinate, string ovaleScale)
        {
            xCoordinateMain = xCoordinate;
            yCoordinateMain = yCoordinate;
            this.ovaleScale = ovaleScale;

            // generate second set of coords.
            if (int.TryParse(yCoordinate, out int yCoord) && double.TryParse(ovaleScale, out double scale))
            {
                xCoordinateAlt = xCoordinate;
                yCoordinateAlt = (yCoord + (int)(13 * scale)).ToString();
            }
        }

        public void Run()
        {
            var process = new Process();
            process.StartInfo.FileName = Path.Combine(Environment.CurrentDirectory, "Tools", "auto_pixelfind.exe");
            process.StartInfo.Arguments = $"{xCoordinateMain} {yCoordinateMain} {xCoordinateAlt} {yCoordinateAlt}";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.Start();
            process.BeginOutputReadLine();
            
            process.WaitForExit();
        }

        private void OutputHandler(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data) && (e.Data.Contains(":")))
                pixelColors = new PixelColors(e.Data);
        }
    }

    public class PixelColors
    {
        public string Color1 { get; private set; }
        public string Color2 { get; private set; }

        public PixelColors(string output)
        {
            var split = output.Split(':');

            Color1 = split[0];
            Color2 = split[1];
        }
    }
}