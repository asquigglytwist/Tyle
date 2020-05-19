using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Prefs
{
    public static class HighlightsHandler
    {
        static HighlightsHandler()
        {
            AllConfigs = new List<VisualCue>();
        }

        public static void Add(VisualCue config)
        {
            lock (AllConfigs)
            {
                AllConfigs.Add(config);
            }
        }

        //public static void Remove(string uniqueID)
        //    => Remove(AllConfigs.FindIndex(x => x.UniqueID.Equals(uniqueID)));

        public static void Remove(int index)
        {
            lock (AllConfigs)
            {
                var count = AllConfigs.Count;
                if (count > 0 && index > 0 && count < index)
                {
                    AllConfigs.RemoveAt(index);
                }
            }
            var exMsg = $"Index {index} out of range for {nameof(AllConfigs)} with {AllConfigs.Count} items.";
            throw new IndexOutOfRangeException(exMsg);
        }

        //public static HighlightConfig TryGetConfigFor(string line)
        //{
        //    var temp = AllConfigs.FindIndex(
        //        c => line.IndexOf(c.Pattern, StringComparison.CurrentCultureIgnoreCase) > -1);
        //    if (temp >= 0)
        //    {
        //        return AllConfigs[temp];
        //    }
        //    return null;
        //}

        public static void UpdateConfigs(List<VisualCue> newConfigs)
        {
            AllConfigs = newConfigs;
            //Preferences.Save(newConfigs);
        }

        public static List<VisualCue> AllConfigs
        { get; set; }
    }
}
