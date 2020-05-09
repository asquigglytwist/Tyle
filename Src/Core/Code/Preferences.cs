﻿using NSJ = Newtonsoft.Json;
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
            var fullJSON = $@"{{
    ""prefsVersion"": {AppMetaData.PrefsVersion},
    ""allConfigs"": {configsInJSON}
}}";
            File.WriteAllText(fileName, fullJSON);
        }

        public static void LoadPrefs(string fileName = PrefsFileName)
        {
            var fullJSON = File.ReadAllText(fileName);
            var prefsObj = NJL.JObject.Parse(fullJSON);
            var configsInJSON = prefsObj.GetValue("allConfigs").ToString();
            HighlightsHandler.AllConfigs = NSJ.JsonConvert.DeserializeObject<List<HighlightConfig>>(configsInJSON);
        }
    }
}
