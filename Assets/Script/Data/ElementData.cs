using System;
using System.Collections.Generic;
using Script.Data.General;
using UnityEngine;

namespace Script.Data
{
    /// <summary>Element 설명 및 관련 특성 데이터</summary>
    [Serializable]
    public class ElementData
    {
        public Element element;
        public List<string> traitIds;
        public string description;
    }
}