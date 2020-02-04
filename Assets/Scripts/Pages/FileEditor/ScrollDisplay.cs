using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDisplay : MonoBehaviour
{

    public GameObject model;
    public int contentIndex;
    public GameObject lastInstance;

    // Start is called before the first frame update
    void Start()
    {
        contentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addContent()
    {
        contentIndex++;
        GameObject newInstance=Instantiate(model,model.transform.position,model.transform.rotation,transform);
        newInstance.SetActive(true);
        lastInstance = newInstance;
    }
}
