using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBar : MonoBehaviour
{
    GameObject child;

    [SerializeField]
    Transform buttonList;
    [SerializeField]
    Transform destination;


    private void Awake()
    {
        child = transform.GetChild(0).gameObject;
    }


    public void OpenBar()
    {
        child.SetActive(true);
    }

    void ClearLst()
    {
        foreach (Transform trf in destination)
            Destroy(trf.gameObject);
    }

    public void UpdateButtons()
    {
        ClearLst();
        GameObject gb;

        foreach (Transform trf in buttonList)
        {
            if (trf.gameObject.activeInHierarchy)
            {
                gb = new GameObject(trf.name);
                gb.transform.SetParent(destination) ;
                gb.transform.localScale = Vector2.one;
                gb.AddComponent<RectTransform>().sizeDelta = Vector2.one * 35f ;                
                gb.AddComponent<Image>().sprite = trf.Find("Image").GetComponent<Image>().sprite;
                gb.AddComponent<Button>().onClick = trf.GetComponentInChildren<Button>().onClick;

            }
        }
    }
}
