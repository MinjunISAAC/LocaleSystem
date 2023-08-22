// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using JsonUtil;
using LocaleSystem.Generate;

namespace Common.Main
{
    public class Main : MonoBehaviour
    {
        void Start()
        {
            JsonParser.LoadJson();
        }
    }
}