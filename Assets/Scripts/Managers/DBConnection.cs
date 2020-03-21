using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class DBConnection : MonoBehaviour
{
   static DBConnection instance;

    public void Initialize()
    {
        instance = this;
    }


    public static void Request(String SqlRequest, Action<JToken> onSuccess, Action<string> onFail)
    {
        instance.StartCoroutine(instance.GetRequest("http://83.199.224.35/?req=" + SqlRequest, onSuccess, onFail));

    }
    

    IEnumerator GetRequest(String httpRequest, Action<JToken> onSuccess, Action<string> onFail) { 

        UnityWebRequest uwr = UnityWebRequest.Get(httpRequest.Replace(" ", "%20"));
        Debug.Log("sending request "+httpRequest);
        yield return uwr.SendWebRequest();


        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
            onFail(uwr.error);
        }
        else
        {
            string result = null;

            try
            {
                // result = uwr.downloadHandler.text;
                // result = Regex.Replace(uwr.downloadHandler.text, "\\[([\\s\\S]*?)\\]", "{Main: [$1]}");
                result = "{ \"Main\": " + uwr.downloadHandler.text + "}";
                // JObject o = new JObject(result);
                JToken o = JObject.Parse(result)["Main"];
                Debug.Log("Received: " + o.ToString());
                 onSuccess(o);
            }
            catch(Exception e)
            {
                Debug.LogException(e);
                onFail("Html error:"+ result);
            }
           // onSuccess(uwr.downloadHandler.text);
        }

    }



#if false

    public void Request(String fileName, Boolean isDownload)
    {

        if (isDownload)
        {
            StartCoroutine(GetFile("http://http://83.114.62.157/Medikit/" + "fileName"));
        } else
        {
            StartCoroutine(UploadFile(fileName));
        }        
    }

    
    public void Request()
    {

    }



    IEnumerator GetFile(string uri)
    {

        using (UnityWebRequest request = UnityWebRequest(uri, "GET", "new downloadHandler, Networking.UploadHandler uploadHandler"))  ;
        {
            yield return request.Send();

            if (request.isError) // Error
            {
                Debug.Log(request.error);
            }
            else // Success
            {
                Debug.Log(request.downloadHandler.text);
            }
        }


    }


    IEnumerator UploadFile(string pathToFile)
    {

    }

#endif

    }
