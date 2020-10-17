using AHK_Builder_Plus_Plus.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        internal void LoadClassList()
        {
            classBox.Items.Clear();

            try
            {
                var fileLink = $"https://raw.githubusercontent.com/simulationcraft/simc/shadowlands/profiles/T{currentTier.Text}_Raid.simc";

                string[] specIndex;
                using (var client = new WebClient())
                using (var reader = new StreamReader(client.OpenRead(fileLink)))
                {
                    specIndex = reader.ReadToEnd().Replace("\n", Environment.NewLine).Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                }

                var classList = specIndex
                                .Where(x => x.StartsWith($"T{currentTier.Text}_"))
                                .Select(x => x.Replace($"T{currentTier.Text}_", "").Replace("_", " ").Replace(".simc", ""))
                                .OrderBy(x => x)
                                .ToArray();

                classBox.Items.AddRange(classList);
            }
            catch
            {
                MessageBox.Show("Could not load specs, please make sure that the current simc tier is set correctly.", "Spec loading error.");
                tabControl1.SelectTab(1);
            }
        }

        private void LoadSpells(string className)
        {
            spellBox.Enabled = false;
            spellBox.Items.Clear();

            var fileLocation = $"https://raw.githubusercontent.com/simulationcraft/simc/shadowlands/profiles/Tier{currentTier.Text}/T{currentTier.Text}_{className.Replace(" ", "_")}.simc";

            try
            {
                string[] spellList;
                using (var client = new WebClient())
                using (var reader = new StreamReader(client.OpenRead(fileLocation)))
                {
                    spellList = reader.ReadToEnd().Replace("\n", Environment.NewLine).Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                                      .Where(x => x.StartsWith("actions") && !(x.Contains("call_action") || x.Contains("run_action") || x.Contains("variable,") || x.Contains("use_items") || x.Contains("snapshot_stats")))
                                      .Select(x => GetRegexMatch(x).Replace("_", " "))
                                      .Where(x => !(string.IsNullOrEmpty(x) || x.Contains("use item")))
                                      .GroupBy(x => x).Select(x => x.First())
                                      .OrderBy(x => x)
                                      .ToArray();
                }

                // Add to spellBox.
                spellBox.Items.AddRange(spellList);
            }
            catch { }
            
            if (spellBox.Items.Count > 0)
                spellBox.Enabled = true;
        }

        private string GetRegexMatch(string text)
        {
            var regexExpression = @"actions[\.]*[a-z_]*[+]*[=][/]*(?:use_item*[,]name[=])*([a-z_]*)[,]*";

            var match = Regex.Match(text, regexExpression);
            if (match.Success)
                return match.Groups[1].Captures[0].ToString();
            else
                return string.Empty;
        }
    }
}
