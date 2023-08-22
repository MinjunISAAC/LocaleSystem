// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using LocaleSystem.ForData;

namespace JsonUtil
{
    public static class JsonParser
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private const string JsonName = "[LocalizeSystem]Sample";

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public static void LoadJson() 
        {
            var loadedJsonFile = Resources.Load<TextAsset>($"JsonSet/{JsonName}");

            if (loadedJsonFile == null)
            {
                Debug.LogError("<color=#FF0000>[JsonParser.LoadJson] Json File이 존재하지 않습니다.</color>");
                return;
            }

            string jsonText = loadedJsonFile.text; // Wrap the JSON text in an object
            
            LocaleDataSet localeDatas = JsonUtility.FromJson<LocaleDataSet>(jsonText); // Parse JSON text

            if (localeDatas == null)
            {
                Debug.LogError("<color=#FF0000>[JsonParser.LoadJson] JSON 파싱에 실패하였습니다.</color>");
                return;
            }
            else
                Debug.Log($"Locale {localeDatas.dataSet.Count} items found");

        }
    }
}