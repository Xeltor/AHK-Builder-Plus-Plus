using AHK_Builder_Plus_Plus.Functions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AHK_Builder_Plus_Plus
{
    public partial class AhkBuilderPlusPlus
    {
        internal void LoadClassList()
        {
            var ovaleScriptLocation = Path.Combine(Properties.Settings.Default.wowLocation, @"interface\addons\Ovale\dist\scripts");

            if (!Directory.Exists(ovaleScriptLocation))
                return;

            var classList = Directory.EnumerateFiles(ovaleScriptLocation, "*_spells.lua", SearchOption.TopDirectoryOnly)
                .Select(x => Path.GetFileNameWithoutExtension(x).Replace("ovale_", "").Replace("_spells", "").FirstCap())
                .ToArray();

            classBox.Items.AddRange(classList);
        }

        private void LoadSpells(string className)
        {
            spellBox.Enabled = false;
            spellBox.Items.Clear();

            var fileLocation = Path.Combine(Properties.Settings.Default.wowLocation, @"interface\addons\Ovale\dist\scripts", $"ovale_{className.ToLower()}_spells.lua");
            var commonSpellLocation = Path.Combine(Properties.Settings.Default.wowLocation, @"interface\addons\Ovale\dist\scripts", $"ovale_common.lua");

            if (!File.Exists(fileLocation))
                return;

            // Get class spells.
            var classSpellList = GenerateSpellList(fileLocation);

            // Get common spells.
            if (File.Exists(commonSpellLocation))
            {
                var commonSpellList = GenerateSpellList(commonSpellLocation);
                classSpellList.AddRange(commonSpellList);
            }

            // Remove duplicates.
            var deduplicatedSpellList = classSpellList.GroupBy(x => x)
                                                      .Select(x => x.First());

            // Add to spellBox.
            spellBox.Items.AddRange(deduplicatedSpellList.ToArray());

            if (spellBox.Items.Count > 0)
                spellBox.Enabled = true;
        }

        private List<string> GenerateSpellList(string fileLocation)
        {
            var spellList = File.ReadAllLines(fileLocation)
                                .Where(x => x.Contains("Define(") && !x.Contains("_buff") && !x.Contains("_debuff") && !x.Contains("_aura") && !x.Contains("_talent") && !x.Contains("_item"))
                                .Select(x => x.Split(' ')[0].Replace("Define(", "").Replace("_", " "))
                                .ToList();

            return spellList;
        }
    }
}
