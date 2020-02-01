using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


[Serializable]
    public class UserInfo//à remplir by nico ?
    {

    //Constructeur

    public UserInfo(string id, UserRole role)
    {
        this.id = id;
        this.role = role;
    }

    //Champs

    private string id;
    private UserRole role;

    //Getters

    public string Id
    {
        get { return id; }
    }    


    public UserRole Role
    {
        get { return role; }
    }

}

