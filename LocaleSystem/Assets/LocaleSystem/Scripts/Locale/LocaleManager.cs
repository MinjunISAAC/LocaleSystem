// ----- C#
using System;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEditor;
using TMPro;

// ----- User Defined
using LocaleSystem.ForUI;
using LocaleSystem.ForData;
using JsonUtil;

namespace LocaleSystem
{
    [System.Serializable]
    public class FontData
    {
        [System.Serializable]
        public class Info
        {
            public TMP_FontAsset fontAsset;
            public float         fontSize;
        }

        public ECountryType  country;
        public Info          info;
    }

    public class LocaleManager : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("UI")]
        [SerializeField] private LocaleSelectView _localeSelectView = null;
        [SerializeField] private List<LocaleUnit> _localeUnitSet    = new List<LocaleUnit>();
        [SerializeField] private List<FontData>   _fontGroup = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Private
        private ECountryType     _countryType   = ECountryType.Unknown;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public void OnInit()
        {
            // 기기의 언어에 맞는 CountryType 지정
            _SetCountryType();

            // Locale Unit Set 초기화
            for (int i = 0; i < _localeUnitSet.Count; i++)
            {
                LocaleUnit unit = _localeUnitSet[i];
                unit.OnInit(_fontGroup);
            }

            // UI 초기화
            _localeSelectView.OnInit(_countryType, _Translate);
            _localeSelectView.OnChangeCountryType += (type) => _ChangeCountryType(type);

            // 초기 번역
            _Translate();
        }

        // ----- Private
        private void _SetCountryType()
        {
            SystemLanguage systemLanguage = Application.systemLanguage;

            switch (systemLanguage)
            {
                case SystemLanguage.Chinese:           _countryType = ECountryType.zh_cn; break;
                case SystemLanguage.ChineseSimplified: _countryType = ECountryType.zh_tw; break;
                case SystemLanguage.Korean:            _countryType = ECountryType.ko;    break;
                case SystemLanguage.Japanese:          _countryType = ECountryType.ja;    break;
                default:                               _countryType = ECountryType.en;    break;
            }
        }

        private void _ChangeCountryType(ECountryType type)
        {
            if (!Enum.IsDefined(typeof(ECountryType), type))
                return;

            _countryType = type;
        }


        private void _Translate()
        {
            for (int i = 0; i < _localeUnitSet.Count; i++)
            {
                LocaleUnit localeUnit = _localeUnitSet[i];
                localeUnit.Translate(_countryType);
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Bind TextMeshProUGUI Unit")]
        public void BindToLocaleUnit()
        {
            TextMeshProUGUI[] tmpArray = FindObjectsOfType<TextMeshProUGUI>();

            for (int i = 0; i < tmpArray.Length; i++)
            {
                var tmp = tmpArray[i];

                if (tmp.GetComponent<LocaleUnit>() == null)
                    tmp.gameObject.AddComponent<LocaleUnit>();

                LocaleUnit localeUnit = tmp.GetComponent<LocaleUnit>();

                _localeUnitSet.Add(localeUnit);
            }

            _SetLocaleUnit();
        }

        private void _SetLocaleUnit()
        {
            JsonParser.LoadJson();
            LocaleDataSet localeDataSet = JsonParser.GetLocaleDataSet();

            for (int i = 0; i < localeDataSet.dataSet.Count; i++)
            {
                LocaleData localeData = localeDataSet.dataSet[i];

                if (Enum.TryParse(localeData.key, out ELocaleKey key))
                {
                    for (int j = 0; j < _localeUnitSet.Count; j++)
                    {
                        var localeUnit = _localeUnitSet[j];
                        if (localeUnit.LocaleKey == key)
                        {
                            localeUnit.SetLocalInfo(localeData.data);
                            break;
                        }
                    }
                }
            }
        }

        private void _SetFont()
        {
            JsonParser.LoadJson();
            LocaleDataSet localeDataSet = JsonParser.GetLocaleDataSet();

            for (int i = 0; i < localeDataSet.dataSet.Count; i++)
            {
                LocaleData localeData = localeDataSet.dataSet[i];

                if (Enum.TryParse(localeData.key, out ELocaleKey key))
                {
                    for (int j = 0; j < _localeUnitSet.Count; j++)
                    {
                        var localeUnit = _localeUnitSet[j];
                        if (localeUnit.LocaleKey == key)
                        {
                            localeUnit.SetLocalInfo(localeData.data);
                            break;
                        }
                    }
                }
            }
        }
#endif
    }
}