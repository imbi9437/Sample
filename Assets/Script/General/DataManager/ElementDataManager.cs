using System.Collections.Generic;
using Script.Data;
using Script.Data.General;
using UnityEngine;

namespace Script.Generic.Manager
{
    public partial class DataManager
    {
        private static Dictionary<Element, ElementData> _elementData;

        private static void InitializeElementData()
        {
            _elementData = new Dictionary<Element, ElementData>();
            ReadData<List<ElementData>>("ElementDB", list =>
            {
                foreach (var data in list)
                {
                    _elementData.TryAdd(data.element, data);
                }
            });
        }

        public static ElementData GetElementData(Element element) => _elementData[element];
    }
}