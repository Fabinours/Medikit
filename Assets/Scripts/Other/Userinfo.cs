using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
    public class UserInfo//à remplir by nico ?
    {


    [SerializeField]
    string code;
    [SerializeField]
    string id;
    [SerializeField]
    string mdp;
    [SerializeField]
    string nom;
    [SerializeField]
    string prenom;
    [SerializeField]
    string tel;
    [SerializeField]
    string dateN;
    [SerializeField]
    string mail;
    [SerializeField]
    string adresse;
    [SerializeField]
    string iban;
    [SerializeField]
    string codeNoeud;
    [SerializeField]
    string role;
    [SerializeField]
    string codeSpe;

    

     

    //Constructeur

    public UserInfo(string id, UserRole role)
    {
        this.id = id;
        this.role = role.ToString();
    }

  
    //Getters

    public string Identifier
    {
        get { return id; }
    }
    public string Code
    {
        get { return code; }
    }
    
    public UserRole Role
    {
        get { return (UserRole)Enum.Parse(typeof(UserRole), role); }
    }

}

