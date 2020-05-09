using NSJ = Newtonsoft.Json;
using NJL = Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tyle;

namespace Core.Code
{
    public static class Preferences
    {
        const string PrefsFileExtension = ".prefs";
        const string PrefsFileName = AppMetaData.ApplicationName + PrefsFileExtension;

        static Preferences()
        {
            //PrefsFileName = $"{AppMetaData.ApplicationName}.{PrefsFileExtension}";
        }

        public static void Save(List<HighlightConfig> newConfigs, string fileName = PrefsFileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException($"Argument {nameof(fileName)} is invalid: NULL, Empty or WhiteSpace");
            }
            var configsInJSON = NSJ.JsonConvert.SerializeObject(newConfigs, NSJ.Formatting.Indented);
            File.WriteAllText(fileName, configsInJSON);
            var fullJSON = $@"{{
    ""prefsVersion"": {AppMetaData.PrefsVersion},
    ""allConfigs"": {configsInJSON}
}}";
            File.WriteAllText(fileName + ".json", fullJSON);
        }

        public static void LoadPrefs(string fileName = PrefsFileName)
        {
            var configsInJSON = File.ReadAllText(fileName);
            HighlightsHandler.AllConfigs = NSJ.JsonConvert.DeserializeObject<List<HighlightConfig>>(configsInJSON);
        }
    }
}
