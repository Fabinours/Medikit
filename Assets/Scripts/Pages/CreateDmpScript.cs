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

    public override void OnOpen()
    {
        //uuid.text = System.Convert.ToBase64String(new byte[] {1,2,3,4 });
        base.OnOpen();
    }

    public void CreateDmp()
    {
        
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

      //  DMP dd = JsonUtility.FromJson<DMP>(dmp.ToString());
    }




}
