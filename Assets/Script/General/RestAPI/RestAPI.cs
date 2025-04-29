using System;
using System.Text;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public static class RestAPI
{
    public enum ServerType
    {
        Out,
        Own
    }
    
    private const double Timeout = 5.0f;
    private const string ServerUri = "";

    private static async UniTaskVoid RequestAsync(UnityWebRequest req, RestAPIClass<string> reVal)
    {
        var cts = new CancellationTokenSource();
        cts.CancelAfterSlim(TimeSpan.FromSeconds(Timeout));

        try
        {
            var res = await req.SendWebRequest().WithCancellation(cts.Token);

            var results = res.downloadHandler.data;
            var message = Encoding.UTF8.GetString(results);
            
            reVal.OnComplete?.Invoke(message);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            Debug.Log(req.responseCode);
        }
        
        req.Dispose();
    }

    public static RestAPIClass<string> Get(string uri, ServerType type = ServerType.Own)
    {
        string url = type == ServerType.Own ? $"{ServerUri}/{uri}" : uri;
        RestAPIClass<string> reVal = new RestAPIClass<string>();
        
        var request = new UnityWebRequest(url, "GET");
        request.downloadHandler = new DownloadHandlerBuffer();
        
        //token 필요시 추가
        
        request.SetRequestHeader("Content-Type","application/json");
        
        RequestAsync(request,reVal).Forget();
        return reVal;
    }

    public static RestAPIClass<string> Post(string uri, string data)
    {
        return null;
    }

    public static RestAPIClass<string> Put()
    {
        return null;
    }

    public static RestAPIClass<string> Delete()
    {
        return null;
    }
}
