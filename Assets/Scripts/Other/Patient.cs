using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Patient//representation d'un patient
{
    [SerializeField]
    string uuid;
    [SerializeField]
    string secu;
    [SerializeField]
    string mut;
    [SerializeField]
    string civilite;
    [SerializeField]
    string nom;
    [SerializeField]
    string prenom;
    [SerializeField]
    string dateNaissance;
    [SerializeField]
    string tel;
    [SerializeField]
    string email;
    [SerializeField]
    string adresse;



    public string Name { get => nom; }
    public string FirstName { get => prenom; }
    public string Uuid { get => uuid; }


    public Patient(string nom, string prenom)//TEST
    {
        this.nom = nom;
        this.prenom = prenom;
        uuid = UnityEngine.Random.Range(0, 999999).ToString();
    }


    public enum CiviliteEnum{Mr, Mme, Autre};

    public CiviliteEnum Civilite
    {
        get { return (CiviliteEnum)Enum.Parse(typeof(CiviliteEnum), civilite); }
    }


}

