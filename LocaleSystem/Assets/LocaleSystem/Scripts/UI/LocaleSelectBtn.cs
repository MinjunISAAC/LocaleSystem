// ----- C#
using LocaleSystem.ForData;
using System;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace LocaleSystem.ForUI
{
    public class LocaleSelectBtn : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Country Type")]
        [SerializeField] private ECountryType _countryType = ECountryType.Unknown;

        [Space(1.5f)] [Header("UI Components")]
        [SerializeField] private Button       _BTN_Select  = null;
        [SerializeField] private Image        _IMG_Check   = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public ECountryType CountryType => _countryType;

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
        public void SetOnClick(Action onClickAction = null)
        {
            _BTN_Select.onClick.AddListener(() => 
            {
                ChangeCountryType(_countryType);
                onClickAction?.Invoke();
            });
        }

        public void OnOffCheckImage(ECountryType type)
        {
            if (_countryType == type)
                _IMG_Check.gameObject.SetActive(true);
            else
                _IMG_Check.gameObject.SetActive(false);
        }
    }
}