using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {   
        InitApplication();
    }

   void InitApplication()
    {
        GameObject.FindObjectOfType<ModuleManager>().Initialize();
        //Todo
        //GameObject.FindObjectOfType<DatabaseManager>().Initialize();
        //GameObject.FindObjectOfType<Translation>().Initialize();
    }
}
