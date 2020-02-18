using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Patient//representation d'un patient
{

  
    string code;
    string id;
    string mdp;
    string nom;
    string prenom;
    string tel;    
    string dateN;
    string mail;
    string adresse;
    string iban;
    string codeNoeud;
    string role;
    string codeSpe;
    string civilite;



    public string Name { get => nom; }
    public string FirstName { get => prenom; }
    public string Uuid { get => code; }

   // public enum Civilite_ {Mr = 0, Mme = 1, Autre = 2 }
    //public Civilite_ Civilite { get => (Civilite_)civilite; }


    public Patient(string nom, string prenom)//TEST
    {
        this.nom = nom;
        this.prenom = prenom;
        code = UnityEngine.Random.Range(0, 999999).ToString();
    }
}

