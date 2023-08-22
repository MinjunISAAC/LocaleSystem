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
    public class LocaleTypeGenerator : MonoBehaviour
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string ENUMFILE_PATH     = "Assets/LocaleSystem/Scripts/Locale/";
        private const string ENUMFILE_NAME     = "ELocaleKey";
        private const string ENUMFILE_KEY_BASE =
            "namespace LocaleSystem \n" +
            "{ \n" +
            "   public enum ELocaleKey\n" +
            "   {\n" +
            "       Unknown = 0,\n";

        // --------------------------------------------------
        // Functions - MenuItem
        // --------------------------------------------------
        [MenuItem("Assets/Custom Menu/Generate LocaleData Type Enum")]
        private static void GenerateToLocaleDataType()
        {
            // Json 파일 로드
            JsonParser.LoadJson();

            LocaleDataSet localeDataSet = JsonParser.GetLocaleDataSet();
            string        filePath      = ENUMFILE_PATH + $"{ENUMFILE_NAME}.cs";
            string        scriptCode    = $"";

            // 파일이 존재하는지 확인
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, scriptCode);
                AssetDatabase.Refresh();
            }
            else
                _DeleteAllLocaleDataKey();

            // Locale Key 부분
            for (int i = 0; i < localeDataSet.dataSet.Count; i++)
            {
                var localeType = localeDataSet.dataSet[i];
                scriptCode += ($"       " + localeType.key + $" = {i+1},\n");
            }
            scriptCode = ENUMFILE_KEY_BASE + scriptCode + "    }\n" + "}";

            File.WriteAllText(filePath, scriptCode);
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