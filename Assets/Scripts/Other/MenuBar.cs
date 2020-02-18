using Newtonsoft.Json.Linq;
using System;
using System.Linq;
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
    InputField searchBarText;

    [SerializeField]
    Transform destination;
    [SerializeField]
    GameObject buttonPref;
    Text buttonPrefText;
    [SerializeField]
    Transform patientListParent;

    List<Patient> storedPatients = new List<Patient>();

    private void Awake()
    {
        buttonPrefText = buttonPref.GetComponentInChildren<Text>();
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

    public void UpdatePatientList()//TODO
    {
        ClearBar_();

        if (searchBarText.text.Length < 2)
            return;

        //searchBarText.text
        DBConnection.Request("SELECT * FROM `Membre` WHERE nom LIKE \"%\" or prenom LIKE \"%\"", UpdatePatientList_Success, UpdatePatientList_Fail);

        //  DBConnection.Request(searchBarText.text);
        // UpdatePatientList_Success(null);
    }

    void UpdatePatientList_Fail(string error)//TODO
    {
        Popup.Log("Menu bar error :" +error);
    }
        void UpdatePatientList_Success(JToken result)//TODO
    {
        GameObject gb;

        //recuperation de Result et remplissage de la liste
        /*
        storedPatients.Add(new Patient("bud", "leTurk"));
        storedPatients.Add(new Patient("davy", "leBoss♥"));
        storedPatients.Add(new Patient("fabien", "curtiss"));
        storedPatients.Add(new Patient("thomas", "lepetittrain"));
        storedPatients.Add(new Patient("maya", "alx cendres"));
        */

        foreach(var obj in result)
        {

            Debug.LogError(obj.ToString());
            storedPatients.Add(JsonUtility.FromJson<Patient>(obj.ToString()));

        }



        foreach (var p in storedPatients)
        {
            buttonPrefText.text = p.FirstName + " " + p.Name;
            gb = GameObject.Instantiate(buttonPref, patientListParent);
            gb.SetActive(true);
            gb.name = p.Uuid;
        }

    }
    public void ClearBar()//code de boucher. pas le temps pour faire dans la dentelle
    {
       Invoke("ClearBar_", 0.2f);
    }

        void ClearBar_()
    {
        foreach (Transform g in patientListParent)        
            Destroy(g.gameObject);
        storedPatients.Clear();
    }

        public void SelectPatient(Button b)//TODO
    {
        //   DBConnection.Resquste( selectPateitn, b.name, SelectPatient_success, SelectPatient_fail)
        //Pour gagner du temps :
        Patient patient = storedPatients.First(p => p.Uuid == b.name);
       ModuleManager.Instance.SetSelectedPatient(patient);
        searchBarText.text = patient.FirstName + " " + patient.Name;
        ClearBar_();
    }


    /*
    public void SelectPatient_fail(string why)
    {
        Popup.Log("An error as occured with the database :"+why);
    }

    public void SelectPatient_success(JObject result)
    {
        Popup.Log("An error as occured with the database :" + why);
    }
    */

    public void SetSelectedPatient(String id)
    {

    }


}
