// ----- C#
using System.Collections;
using System.Collections.Generic;
using System.IO;

// ----- Unity
using UnityEngine;
using UnityEditor;

// ----- User Defined
using LocaleSystem.ForData;
using JsonUtil;

namespace LocaleSystem.Generate
{
    public class JsonTypeGenerator : MonoBehaviour
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string ENUMFILE_PATH = "Assets/JsonLoader/Scripts/";
        private const string ENUMFILE_NAME = "ELocaleType";
        private const string ENUMFILE_BASE =
            "namespace LocaleSystem \n" +
            "{ \n" +
            "   public enum ELocaleType\n" +
            "   {\n" +
            "       Unknown = 0,\n";

        // --------------------------------------------------
        // Functions - MenuItem
        // --------------------------------------------------
        [MenuItem("Assets/Custom Menu/Generate LocaleData Type Enum")]
        private static void GenerateToLocaleDataType()
        {
            _DeleteAllLocaleDataKey();

            // Json Load
            JsonParser.LoadJson();

            LocaleDataSet localeDataSet = JsonParser.GetLocaleDataSet();
            string fileName = ENUMFILE_PATH + $"{ENUMFILE_NAME}.cs";
            string scriptCode = $"";

            for (int i = 0; i < localeDataSet.dataSet.Count; i++)
            {
                var localeType = localeDataSet.dataSet[i];
                scriptCode += ($"       " + localeType.key + $" = {i+1},\n");
            }
            
            scriptCode = ENUMFILE_BASE + scriptCode + "    }\n" + "}";
            File.WriteAllText(fileName, scriptCode);
            AssetDatabase.Refresh();
        }

        private static void _DeleteAllLocaleDataKey()
        {
            string fileName   = ENUMFILE_PATH + $"{ENUMFILE_NAME}.cs";
            string scriptCode = $"";

            File.WriteAllText(fileName, scriptCode);
            AssetDatabase.Refresh();
        }
    }
}