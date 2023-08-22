// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using JsonUtil;
using LocaleSystem.Generate;
using LocaleSystem;

namespace Common.Main
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LocaleManager _localeMamager = null;

        void Start()
        {
            JsonParser.LoadJson();
            _localeMamager.OnInit();
        }
    }
}