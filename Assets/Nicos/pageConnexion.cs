using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pageConnexion : MonoBehaviour
{

    public InputField id;
    public InputField pwd;
    public GameObject invalideIDS;
    public GameObject PageAdmin;
    public GameObject MainPageAdmin;
    public GameObject Connexion;
    public Dictionary<string, string> ids = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        ids.Add("toto","tita");
        ids.Add("nicolas","fernandes");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void printID()
    {
     
        string ID = id.text;
        string password = pwd.text;
        if (ids.TryGetValue(ID, out password))
        {
            print("Vrai");
            invalideIDS.SetActive(false);
            PageAdmin.SetActive(true);
            MainPageAdmin.SetActive(true);
            Connexion.SetActive(false);
        } 
            
       
        else
        {
            print("Faux");
            invalideIDS.SetActive(true);
            PageAdmin.SetActive(false);
            PageAdmin.SetActive(false);
            PageAdmin.SetActive(true);
        }
    }


}
