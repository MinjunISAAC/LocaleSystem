// ----- C#
using System;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using TMPro;

// ----- User Defined
using LocaleSystem.ForData;

namespace LocaleSystem
{
    public class LocaleUnit : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private ELocaleKey      _localeKey  = ELocaleKey.Unknown;
        [SerializeField] private TextMeshProUGUI _TMP_Text   = null;
        [SerializeField] private LocaleInfo      _localeInfo = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private Dictionary<ECountryType, FontData> _fontDataSet = new Dictionary<ECountryType, FontData>();

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public ELocaleKey LocaleKey => _localeKey;

        // --------------------------------------------------
        // Translate Event
        // --------------------------------------------------
        public event Action<ECountryType> OnTranslate;
        public void Translate(ECountryType type) 
        {
            if (OnTranslate != null)
                OnTranslate(type);
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(List<FontData> fontGroup)
        {
            for (int i = 0; i < fontGroup.Count; i++)
            {
                var fontData = fontGroup[i];
                _fontDataSet.Add(fontData.country, fontData);
            }

            
            OnTranslate += (type) => _Traslate(type);
        }

        public void SetLocalInfo(LocaleInfo localeInfo)
        {
            _localeInfo = localeInfo;
        }

        private void _Traslate(ECountryType type)
        {
            if (_TMP_Text == null)
                return;

            if (_fontDataSet.TryGetValue(type, out FontData fontData))
            {
                _TMP_Text.font     = fontData.info.fontAsset;
                _TMP_Text.fontSize = fontData.info.fontSize;
            }

            switch (type)
            {
                case ECountryType.zh_cn: _TMP_Text.text = _localeInfo.zh_cn; break;
                case ECountryType.zh_tw: _TMP_Text.text = _localeInfo.zh_tw; break;
                case ECountryType.ko:    _TMP_Text.text = _localeInfo.ko;    break;
                case ECountryType.ja:    _TMP_Text.text = _localeInfo.ja;    break;
                default:                 _TMP_Text.text = _localeInfo.en;    break;
            }
        }
    }
}