using System;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static object _lock = new object();
    private static bool _isApplicationQuit = false;

    public bool isEternal;

    public static T Instance
    {
        get
        {
            lock (_lock)
            {
                if (_isApplicationQuit) return null;

                if (_instance == false) _instance = FindAnyObjectByType<T>();
                if (_instance != false) return _instance;

                var obj = new GameObject(typeof(T).Name);
                _instance = obj.AddComponent<T>();

                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        if (_instance) Destroy(gameObject);
        else _instance = this as T;

        if (isEternal) DontDestroyOnLoad(gameObject);
    }

    private void OnApplicationQuit()
    {
        _isApplicationQuit = true;
    }
}
