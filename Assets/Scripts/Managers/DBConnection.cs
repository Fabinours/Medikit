using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DBConnection : MonoBehaviour
{

    public void Initialize()
    {

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
