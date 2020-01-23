using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDisplay : MonoBehaviour
{

    public GameObject model;

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
        Instantiate(model,model.transform.position,model.transform.rotation,transform);
    }
}
