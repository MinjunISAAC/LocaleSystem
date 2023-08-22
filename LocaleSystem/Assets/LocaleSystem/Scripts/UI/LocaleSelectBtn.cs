// ----- C#
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
        //[Header("Country Type")]
        //[SerializeField] private 

        [Space(1.5f)] [Header("UI Components")]
        [SerializeField] private Button _BTN_Select = null;
        [SerializeField] private Image  _IMG_Check  = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        public void Start() { _IMG_Check.gameObject.SetActive(false); }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void SetOnClick(Action onClickAction)
        {

        }
    }
}