using System;
using System.Collections.Generic;
using Script.Data;
using UnityEngine;

namespace Script.Generic
{
    public partial class SaveLoadSystem
    {
        private static readonly Dictionary<Type, object> Subscribe = new();

        public static Events<T> GetSubscribe<T>()
        {
            var type = typeof(T);

            if (Subscribe.ContainsKey(type) == false)
                Subscribe.TryAdd(type, new Events<T>());

            return (Events<T>)Subscribe[type];
        }
        
        public class Events<T>
        {
            public EventHandler<SaveDataArgs<T>> OnCompleteSave;
            public EventHandler<LoadDataArgs<T>> OnCompleteLoad;

            public void RegisterSave(EventHandler<SaveDataArgs<T>> callback)
            {
                OnCompleteSave += callback;
            }
            
            public void RegisterLoad(EventHandler<LoadDataArgs<T>> callback)
            {
                OnCompleteLoad += callback;
            }
            
            public void UnRegisterSave(EventHandler<SaveDataArgs<T>> callback)
            {
                OnCompleteSave -= callback;
            }
            
            public void UnRegisterLoad(EventHandler<LoadDataArgs<T>> callback)
            {
                OnCompleteLoad -= callback;
            }
        }
    }
}