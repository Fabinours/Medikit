using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Patient//representation d'un patient
{
    string uuid;
    string secu;
    string mut;
    int civilite;
    string nom;
    string prenom;
    DateTime date;
    string tel;
    string email;
    string adr;

    public string Name { get => nom; }
    public string FirstName { get => prenom; }
    public string Uuid { get => uuid; }


    public Patient(string nom, string prenom)//TEST
    {
        this.nom = nom;
        this.prenom = prenom;
        uuid = UnityEngine.Random.Range(0, 999999).ToString();
    }
}

