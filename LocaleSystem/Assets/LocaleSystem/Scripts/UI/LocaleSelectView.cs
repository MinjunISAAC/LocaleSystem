// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using LocaleSystem.ForData;

namespace LocaleSystem.ForUI
{
    public class LocaleSelectView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private List<LocaleSelectBtn> _btnSet = new List<LocaleSelectBtn>();

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        [SerializeField] private ECountryType _countryType = ECountryType.Unknown;

        // --------------------------------------------------
        // Change Country Type Event
        // --------------------------------------------------
        public event Action<ECountryType> OnChangeCountryType;
        public void ChangeCountryType(ECountryType countryType)
        {
            if (OnChangeCountryType != null)
                OnChangeCountryType(countryType);
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(ECountryType countryType, Action doneCallBack)
        {
            _countryType = countryType;

            for (int i = 0; i < _btnSet.Count; i++)
            {
                var btn = _btnSet[i];

                btn.OnChangeCountryType += (type) => 
                {
                    _ChangeCountryType(type);

                    _UnActiveAllCheckImage();
                    btn.OnOffCheckImage(_countryType);
                };

                btn.SetOnClick(doneCallBack);
                btn.OnOffCheckImage(_countryType);
            }
        }

        // ----- Private
        private void _ChangeCountryType(ECountryType type)
        {
            if (!Enum.IsDefined(typeof(ECountryType), type))
                return;

            _countryType = type;
            ChangeCountryType(_countryType);
        }

        private void _UnActiveAllCheckImage()
        {
            for (int i = 0; i < _btnSet.Count; i++)
            {
                var btn = _btnSet[i];
                btn.OnOffCheckImage(ECountryType.Unknown);
            }
        }
    }
}