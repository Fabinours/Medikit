using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleManager : MonoBehaviour
{

    //Singleton accessor
    public static ModuleManager Instance { get { return instance; } }
    private static ModuleManager instance;
    
    private List<BaseModule> lastPages = new List<BaseModule>();
    private BaseModule currentActiveModule;



    [SerializeField]
    private MainPage mainPage;



    public void Initialize()//called by ApplicationManager
    {
        instance = this;
        OpenModule(mainPage);
    }


    public void OpenModule(BaseModule module)
    {
        if(currentActiveModule != null)
        {
            currentActiveModule.OnClose();
            currentActiveModule.gameObject.SetActive(true);
        }

        if (lastPages.Count > 0 && lastPages[lastPages.Count-1] != module)
        {
            lastPages.Add(module);
        }

        module.gameObject.SetActive(true);
        module.OnOpen();
        }


    public void BackModule()
    {
        if (lastPages.Count > 0)
        {
            OpenModule(lastPages[lastPages.Count - 1]);
            lastPages.RemoveAt(lastPages.Count - 1);
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }


    public void SetSelectedPatient(string id)
    {
        Debug.LogWarning("TODO SetSelectedPatient - need database");
    }



    public Object GetSelectedPatient()
 {
        Debug.LogWarning("TODO GetSelectedPatient - need database");
        return null;
 }
 
}
