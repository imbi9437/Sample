using System;
using UnityEngine;

[Serializable]
public class RestAPIClass<T>
{
    public Action<T> OnComplete = null;

    public bool success;
    public string code;
    public string message;
    public string httpStatus;
    public T data;
}
