using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddMemberScript : MonoBehaviour

{
    public InputField matricule;
    public Toggle mr;
    public Toggle mme;
    public Toggle other;
    public InputField nom;
    public InputField prenom;
    public InputField day;
    public InputField month;
    public InputField year;
    public InputField adress;
    public InputField CP;
    public InputField city;
    public InputField tel;
    public InputField mail;
    public Dropdown profil;
    public Dropdown affectation;
    public InputField id;
    public InputField iban;
    public Dropdown specialite;
    private Dictionary<string, int> affectationOptions = new Dictionary<string, int>();
    private Dictionary<string, int> specialiteOptions = new Dictionary<string, int>();

    // Start is called before the first frame update
    void Start()
    {
        DBConnection.Request("SELECT * FROM Noeud", Affect_Success, Affect_Fail);
        DBConnection.Request("SELECT * FROM SpecialiteMedecine", Spec_Success, Spec_Fail);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        string pro = profil.captionText.text;
        print(pro);
        string civilCheck="";
        if (mr.isOn)
        {
            civilCheck = "mr";
        }
        else if(mme.isOn)
        {
            civilCheck = "mme";
        }
        else if(other.isOn)
        {
            civilCheck = "autre";
        }

        int mat= Convert.ToInt32(matricule.text);

        string caracteres = "azertyuiopqsdfghjklmwxcvbn";
        System.Random selAlea = new System.Random();


        string sel = "";
        for (int i = 0; i < 8; i++) // 8 caracteres
        {
            int majOrMin = selAlea.Next(2);
            string carac = caracteres[selAlea.Next(0, caracteres.Length)].ToString();
            if (majOrMin == 0)
            {
                sel += carac.ToUpper(); // Maj
            }
            else
            {
                sel += carac.ToLower(); //Min
            }
        }
        print(sel);


        string fullDate = year.text + "-" + month.text + "-" + day.text;
        string fullAdress = adress.text + " " + CP.text + " " + city.text;
        int optionOfAffect = affectationOptions[affectation.captionText.text];
        int optionOfSpec = specialiteOptions[specialite.captionText.text];
        DBConnection.Request("INSERT INTO `Membre` VALUES ("+mat+",'"+id.text+"','"+sel+"','"+nom.text+"','"+prenom.text+"','"+tel.text+"','"+fullDate+"','"+mail.text+"','"+fullAdress+"','"+iban.text+"',"+optionOfAffect+",'"+ profil.captionText.text+"',"+optionOfSpec+",'"+civilCheck+"')", AddMember_Success, AddMember_Fail);
    
    
    }

    void AddMember_Fail(string error)
    {
        Popup.Log("Request error :" + error);
    }

    void AddMember_Success(JToken result)
    {
        print(result.ToString());
    }

    void Affect_Fail(string error)
    {
        Popup.Log("Request error :" + error);
    }

    void Affect_Success(JToken result)
    {
        List<string> tabOptions = new List<string>();
        foreach(var obj in result)
        {
            string nameNoeud = (string) obj["nom"];
            tabOptions.Add(nameNoeud);
            affectationOptions.Add((string)obj["nom"], (int)obj["code"]);
        }
        affectation.AddOptions(tabOptions);
    }

    void Spec_Success(JToken result)
    {
        List<string> specOptions = new List<string>();
        foreach(var obj in result)
        {
            string nameSpe = (string)obj["libelleSpe"];
            specOptions.Add(nameSpe);
            specialiteOptions.Add((string)obj["libelleSpe"], (int)obj["codeSpe"]);
        }
        specialite.AddOptions(specOptions);
    }

    void Spec_Fail(string error)
    {
        Popup.Log("Request error :" + error);
    }
}
