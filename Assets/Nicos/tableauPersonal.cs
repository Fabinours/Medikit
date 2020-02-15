using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tableauPersonal : MonoBehaviour
{

    public GameObject line;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addContent()
    {
        GameObject newLine = Instantiate(line, line.transform.position, line.transform.rotation, transform);
        newLine.SetActive(true);
       
    }

}
