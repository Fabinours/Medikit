using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoScript : MonoBehaviour
{
    public static UserInfoScript Instance { get { return userInfoInstance; } }//Singleton : Pour acceder a  cette classe depuis n'importe où, 
    private static UserInfoScript userInfoInstance;                           //utiliser UserInfo.Instance.Fonction()

    UserInfo currentUser;


    private void Awake()
    {
        userInfoInstance = this;
    }

    public void TryRegister(string id, string pwd, Action callbackSuccess, Action<string> callbackFail)
    {
        //todo : call bdd et rempli un UserInfo avec le resultat. Appeler la bonne fonction selon le retour (erreur ou pas)

        currentUser = new UserInfo("Bob", UserRole.Infirmier);

       // callbackSuccess();

        callbackFail("Error !");
    }

    public void RegisterLastSession(Action callbackSuccess, Action callbackFail)
    {
        //todo : essaie de se connecter a la dernier session et appelle callbackSuccess si réussi, sinon callbackFail
        currentUser = new UserInfo("Bob", UserRole.Infirmier);


        callbackSuccess();
        //callbackFail();

    }

    public void Logout()
    {
        currentUser = null;
        //todo : suprrimer les info de derniere connexion
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public UserInfo GetValues()
    {
        return currentUser;
    }



}
