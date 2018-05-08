using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus.Functions
{
    internal class WoWConfig
    {
        private string ConfigLocation;

        public WoWConfig()
        {
            ConfigLocation = Path.Combine(Properties.Settings.Default.wowLocation, "WTF", "Config.wtf");
        }

        public bool IsUiScaleEnabled()
        {
            if (!File.Exists(ConfigLocation))
                return false;

            var lines = File.ReadAllLines(ConfigLocation);

            return lines.Where(x => x.Contains("useUiScale")).Any();
        }

        public double Scaler()
        {
            if (!File.Exists(ConfigLocation))
                return 0;

            var lines = File.ReadAllLines(ConfigLocation);
            var uiScaleString = lines.First(x => x.StartsWith("SET uiScale"))
                               .Replace("\"", "")
                               .Replace("SET uiScale ", "");

            var culture = CultureInfo.CreateSpecificCulture("en-GB");
            if (!double.TryParse(uiScaleString, NumberStyles.Any, culture, out double uiScale))
                return 0;

            var Scaler = uiScale * Normalizer();

            return Scaler;
        }

        private double Normalizer()
        {
            var Normalizer = (double)Screen.PrimaryScreen.Bounds.Height / 768;

            return Normalizer;
        }
    }
}
