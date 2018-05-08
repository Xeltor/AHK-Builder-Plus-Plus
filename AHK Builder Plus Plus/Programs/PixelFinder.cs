using System;
using System.Diagnostics;
using System.IO;

namespace AHK_Builder_Plus_Plus.Programs
{
    internal class PixelFinder
    {
        private int xCoordinateMain;
        private int yCoordinateMain;
        private int xCoordinateAlt;
        private int yCoordinateAlt;

        public PixelColors pixelColors { get; private set; }

        public PixelFinder(int FirstXCoordinate, int FirstYCoordinate, int SecondXCoordinate, int SecondYCoordinate)
        {
            xCoordinateMain = FirstXCoordinate;
            yCoordinateMain = FirstYCoordinate;

            xCoordinateAlt = SecondXCoordinate;
            yCoordinateAlt = SecondYCoordinate;
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