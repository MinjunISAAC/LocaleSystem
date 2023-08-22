// ----- C#
using System.Collections.Generic;

namespace LocaleSystem.ForData
{
    [System.Serializable]
    public class LocaleInfo
    {
        public string en;
        public string zh_cn;
        public string zh_tw;
        public string ja;
        public string ko;
    }

    [System.Serializable]
    public class LocaleData
    {
        public string     key;
        public LocaleData data;
    }

    [System.Serializable]
    public class LocaleDataSet
    {
        public List<LocaleData> dataSet = new List<LocaleData>();
    }
}