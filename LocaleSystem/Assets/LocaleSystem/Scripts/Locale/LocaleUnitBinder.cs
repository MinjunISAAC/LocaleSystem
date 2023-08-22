// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using TMPro;

// ----- User Defined
using UnityEditor;

namespace LocaleSystem
{
    public class LocaleUnitBinder : MonoBehaviour
    {
        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        [MenuItem("Assets/Custom Menu/Create TextMeshProUGUI Unit")]
        public static void CreateToLocaleUnit()
        {
            TextMeshProUGUI[] tmpArray = FindObjectsOfType<TextMeshProUGUI>();
            
            for (int i = 0; i < tmpArray.Length; i++) 
            {
                var tmp = tmpArray[i];

                if (tmp.GetComponent<LocaleUnit>() == null) 
                    tmp.gameObject.AddComponent<LocaleUnit>();
            }
        }
    }
}