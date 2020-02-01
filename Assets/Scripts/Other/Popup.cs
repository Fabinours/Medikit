using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
   private static Popup popup;

    [SerializeField]
    private Text msg;
    [SerializeField]
    private GameObject obj;

    void Awake()
    {
        popup = this;
     }
    public static void Log(string txt)
    {
        popup.PrintMessage(txt);
        Debug.LogError(txt);
    }


    private void PrintMessage(string txt)
    {
        msg.text = txt;
        obj.SetActive(true);
    }
  


}
