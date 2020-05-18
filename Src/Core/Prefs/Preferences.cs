using NSJ = Newtonsoft.Json;
using NJL = Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Tyle;

namespace Core.Code
{
    #region Preferences
    /// <summary>
    /// Handles all User Preferences
    /// </summary>
    public static class Preferences
    {
        #region Fields
        /// <summary>
        /// Extension for the <see cref="Preferences"/> file
        /// </summary>
        const string PrefsFileExtension = ".prefs";
        /// <summary>
        /// Default name for the saved <see cref="Preferences"/> file
        /// </summary>
        const string PrefsFileName = AppMetaData.ApplicationName + PrefsFileExtension;

        /// <summary>
        /// JSON Property Name for the Version of the <see cref="Preferences"/> save file format
        /// </summary>
        const string JPN_PrefsVersion = "prefsVersion";
        /// <summary>
        /// JSON Property Name for the serialized <see cref="Rule"/>(s)
        /// </summary>
        const string JPN_AllRules = "allRules";
        #endregion // Fields

        #region Properties
        /// <summary>
        /// <see cref="List{T}"/> of all <see cref="Rule"/>(s)
        /// </summary>
        public static List<Rule> Rules
        { get; private set; }
        #endregion // Properties

        #region Methods
        /// <summary>
        /// Save all <see cref="Rule"/> (<paramref name="newRules"/>) to <see cref="Preferences"/> file: <paramref name="fileName"/>
        /// </summary>
        /// <param name="newRules">New <see cref="Rule"/>(s)</param>
        /// <param name="fileName">Preferences file to save the <see cref="Rule"/>(s) into</param>
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

        /// <summary>
        /// Load all <see cref="Preferences"/> from <paramref name="fileName"/> file
        /// </summary>
        /// <param name="fileName">Path to the <see cref="Preferences"/> file</param>
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
        #endregion // Methods
    }
    #endregion // Preferences
}
