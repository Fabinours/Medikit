using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class ConsultDMPScript : BaseModule
{

    public Dropdown dropdownAuteur;
    // public Dropdown dropdownProfession;
    public InputField inputTitre;
    public Dropdown dropdownType;
    public InputField inputDu;
    public InputField inputAu;
    public GameObject tableContent;
    public GameObject lineModel;
    List<GameObject> generatedRows = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRechercherClick()
    {
        foreach (var o in generatedRows) Destroy(o);

        // string auteur = dropdownAuteur.options[dropdownAuteur.value].text;
        // string profession = dropdownProfession.options[dropdownProfession.value].text;
        string titre = inputTitre.text;
        string type = dropdownType.options[dropdownType.value].text;
        string du = inputDu.text;
        string au = inputAu.text;

        string uuidPatient = ModuleManager.Instance.GetSelectedPatient().Uuid;

        string req = "SELECT Document.* FROM DMP NATURAL JOIN Acte NATURAL JOIN Constitue NATURAL JOIN Document WHERE DMP.uuid like '%" + uuidPatient + "%' ";

       // if (auteur != "")
       //     req += "AND auteur like '%" + auteur + "%' ";
        if (titre != "")
            req += "AND nomDoc like '%" + titre + "%' ";
        
        if (type != "tous")
            req += "AND soustype like '%" + type + "%'";
        /*
        if (du != "")
            req += "AND dateEnregistrement >= '" + du + "' ";
        if (au != "")
            req += "AND dateEnregistrement <= '" + au + "' ";
   */
        DBConnection.Request(req, onSearchSuccess, onSearchFail);


    }


    public void onSearchSuccess(JToken result)
    {

        foreach (var ligne in result)
        {
            GameObject newLine = Instantiate(lineModel, tableContent.transform);
            newLine.SetActive(true);
            newLine.transform.Find("Type").GetComponent<Text>().text = result[0]["soustype"].ToString();
            newLine.transform.Find("Titre").GetComponent<Text>().text = result[0]["nomDoc"].ToString();
            newLine.transform.Find("DebutDeLActe").GetComponent<Text>().text = result[0]["dateEnregistrement"].ToString();
            //  newLine.transform.Find("Profession").GetComponent<Text>().text = result["auteur"];
            newLine.transform.Find("Auteur").GetComponent<Text>().text = result[0]["auteur"].ToString();
            generatedRows.Add(newLine);
        }
    }

    private void onSearchFail(string str)
    {

    }

    public void duplicateLine()
    {
   //     GameObject newLine = Instantiate(lineModel)
    }
}









