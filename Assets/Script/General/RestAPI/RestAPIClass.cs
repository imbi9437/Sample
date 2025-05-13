using System;
using UnityEngine;
using Action = Unity.Android.Gradle.Manifest.Action;

[Serializable]
public class RestAPIClass<T>
{
    private bool _isComplete = false;
    private Action<T> _onComplete = null;

    public Action<T> OnComplete
    {
        get => _onComplete;
        set
        {
            _onComplete = value;
            if (_isComplete) _onComplete?.Invoke(data);
        }
    }

    public bool success;
    public string code;
    public string message;
    public string httpStatus;
    public T data;

    public void Complete(T result)
    {
        data = result;
        _isComplete = true;
        _onComplete?.Invoke(data);
    }
}
