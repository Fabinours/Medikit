using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateDmpScript : BaseModule
{
    [SerializeField]
    InputField uuid;
    [SerializeField]
    InputField num_secu;
    [SerializeField]
    InputField num_mut;
    [SerializeField]
    Dropdown civilite;
    [SerializeField]
    InputField nom;
    [SerializeField]
    InputField prenom;
    [SerializeField]
    InputField dateNaissance;

    [SerializeField]
    InputField tel;
    [SerializeField]
    InputField email;
    [SerializeField]
    InputField adresse;

    public override void OnClose()
    {
        base.OnClose();
    }

    private void OnEnable()
    {
        byte RD() {return (byte)UnityEngine.Random.Range(0, 255); };

        uuid.text = System.Convert.ToBase64String(new byte[] { RD(), RD(), RD(), RD(), RD(), RD(), RD() });
    }

    public override void OnOpen()
    {
        base.OnOpen();
    }

    public void CreateDmp()
    {
        
        //Ne sert a rien mais cest marrant
           var dmp = new JObject();
        dmp.Add("uuid", uuid.text);
        dmp.Add("secu", num_secu.text);
        dmp.Add("mut", num_mut.text);
        dmp.Add("civilite", civilite.value);
        dmp.Add("nom", nom.text);
        dmp.Add("prenom", prenom.text);
        dmp.Add("date", dateNaissance.text);
        dmp.Add("tel", tel.text);
        dmp.Add("email", email.text);
        dmp.Add("adr", adresse.text);
        print(dmp);

        var req = String.Format(
            "INSERT INTO `DMP`(`uuid`, `nom`, `prenom`, `tel`, `email`, `adresse`, `dateNaissance`, `villeNaissance`, `actVille`, `secu`, `civilite`) " +
                     "VALUES( '{0}' ,  '{1}' ,   '{2}'  , '{3}' , '{4}'  , '{5}'  ,'{6}' , '{7}'  , NULL  , '{9}'  , '{10}'  )", 
                               uuid.text, nom.text, prenom.text, tel.text, email.text, adresse.text, dateNaissance.text, adresse.text, adresse.text, num_secu.text,  ((Patient.CiviliteEnum)civilite.value).ToString()            );

        DBConnection.Request(req, OnSuccessAdd, OnFailAdd);
        

      //  DMP dd = JsonUtility.FromJson<DMP>(dmp.ToString());
    }

    void OnFailAdd(string error)
    {
        Popup.Log(error);
    }

    void OnSuccessAdd(JToken result )
    {
        Popup.Log("DMP ajouté !");
        Back();
    }







}
