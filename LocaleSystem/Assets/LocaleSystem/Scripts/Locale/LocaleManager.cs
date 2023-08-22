// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using LocaleSystem.ForUI;
using LocaleSystem.ForData;

namespace LocaleSystem
{
    public class LocaleManager : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private LocaleSelectView _localeSelectView = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        [SerializeField] private ECountryType _countryType = ECountryType.Unknown;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        // ----- Public
        public void OnInit()
        {
            // 기기의 언어에 맞는 CountryType 지정
            _SetCountryType();

            // UI 초기화
            _localeSelectView.OnInit(_countryType);
            _localeSelectView.OnChangeCountryType += (type) => _ChangeCountryType(type);
        }

        // ----- Private
        private void _ChangeCountryType(ECountryType type)
        {
            if (!Enum.IsDefined(typeof(ECountryType), type))
                return;

            _countryType = type;
        }

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
    }
}