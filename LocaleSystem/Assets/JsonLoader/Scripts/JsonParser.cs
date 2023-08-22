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
        // ----- Const
        private const string JSONFILE_NAME = "[LocalizeSystem]Sample";

        // ----- Private
        private static LocaleDataSet _dataSet = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public static void LoadJson() 
        {
            var loadedJsonFile = Resources.Load<TextAsset>($"JsonSet/{JSONFILE_NAME}");

            if (loadedJsonFile == null)
            {
                Debug.LogError("<color=#FF0000>[JsonParser.LoadJson] Json File이 존재하지 않습니다.</color>");
                return;
            }

            _dataSet = JsonUtility.FromJson<LocaleDataSet>(loadedJsonFile.text);

            if (_dataSet == null)
            {
                Debug.LogError("<color=#FF0000>[JsonParser.LoadJson] JSON 파싱에 실패하였습니다.</color>");
                return;
            }
        }

        public static LocaleDataSet GetLocaleDataSet() 
        {
            if (_dataSet == null)
                return null;

            return _dataSet;
        }
    }
}