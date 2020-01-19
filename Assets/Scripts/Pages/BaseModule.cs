using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseModule : MonoBehaviour
{
    [SerializeField]
    private GameObject defaultPage;

    private Stack<GameObject> lastPages = new Stack<GameObject>();
    private GameObject currentPage;



    public virtual void OnOpen()
    {
        foreach (var t in lastPages)
            t.SetActive(false);
        lastPages = new Stack<GameObject>();
        OpenPage(defaultPage);
    }

    public virtual void OnClose()
    {
        
    }


    public void Back()
    {
        currentPage.SetActive(false);

        if (lastPages.Count == 0)
            ModuleManager.Instance.BackModule();
        else {
            currentPage = lastPages.Pop();
            currentPage.SetActive(true);
        }
    }

    public void OpenPage(GameObject page)
    {
        if (currentPage != null)
        {
            currentPage.SetActive(false);
            lastPages.Push(currentPage);
        }
        page.SetActive(true);   
        currentPage = page;     
    }


}
