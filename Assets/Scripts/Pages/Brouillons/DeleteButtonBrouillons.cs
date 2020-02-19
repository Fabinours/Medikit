using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteButtonBrouillons : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = transform.GetChild(0).GetComponent<Button>();
        button.onClick.AddListener(deleteButton);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (transform.parent.parent.parent.childCount == 3)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }*/
    }

    void deleteButton()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
