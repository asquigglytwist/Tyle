using NSJ = Newtonsoft.Json;
using NJL = Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tyle;

namespace Core.Code
{
    /// <summary>
    /// Handles all User Preferences
    /// </summary>
    public static class Preferences
    {
        /// <summary>
        /// Extension for the Preferences file
        /// </summary>
        const string PrefsFileExtension = ".prefs";
        /// <summary>
        /// Default name for the saved Preferences file
        /// </summary>
        const string PrefsFileName = AppMetaData.ApplicationName + PrefsFileExtension;

        /// <summary>
        /// JSON Property Name for the Version of the Preferences save file format
        /// </summary>
        const string JPN_PrefsVersion = "prefsVersion";
        /// <summary>
        /// JSON Property Name for the serialized <see cref="Rule"/>(s)
        /// </summary>
        const string JPN_AllRules = "allRules";

        public static List<Rule> Rules
        { get; private set; }

        public static void Save(List<Rule> newRules, string fileName = PrefsFileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException($"Argument {nameof(fileName)} is invalid: NULL, Empty or WhiteSpace");
            }
            var rulesInJSON = NSJ.JsonConvert.SerializeObject(newRules,
                NSJ.Formatting.Indented);
            var fullJSON = $@"{{
    ""{JPN_PrefsVersion}"": {AppMetaData.PrefsVersion},
    ""{JPN_AllRules}"": {rulesInJSON}
}}";
            try
            {
                File.WriteAllText(fileName, fullJSON);
            }
            catch (Exception)
            {
                //var tempFile = Path.GetTempFileName();
                //File.WriteAllText(tempFile, fullJSON);
                throw;
            }
        }

        public static void Load(string fileName = PrefsFileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    var fullJSON = File.ReadAllText(fileName);
                    var prefsObj = NJL.JObject.Parse(fullJSON);
                    var configsInJSON = prefsObj.GetValue("allConfigs").ToString();
                    Rules = NSJ.JsonConvert.DeserializeObject<List<Rule>>(configsInJSON); 
                }
                //else
                //{
                //    throw new FileNotFoundException($"Prefs file not found:  {fileName}");
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
