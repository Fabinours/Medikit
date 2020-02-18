using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoScript : MonoBehaviour
{
    public static UserInfoScript Instance { get { return userInfoInstance; } }//Singleton : Pour acceder a  cette classe depuis n'importe où, 
    private static UserInfoScript userInfoInstance;                           //utiliser UserInfo.Instance.Fonction()

    UserInfo currentUser;

    private const string keySaveSession = "last_session";

    private void Awake()
    {
        userInfoInstance = this;
    }

    public void TryRegister(string id, string pwd, Action callbackSuccess, Action<string> callbackFail)
    {

        DBConnection.Request("SELECT * FROM `Membre` WHERE mdp like \"" + pwd + "\" and id like \"" + id+"\"",
            (result) =>
        {
            string val = result.First.ToString();
            PlayerPrefs.SetString(keySaveSession, val);


            currentUser = JsonUtility.FromJson<UserInfo>(val);
            callbackSuccess();
        }, callbackFail);


    }

    public void RegisterLastSession(Action callbackSuccess, Action callbackFail)
    {
        //todo : essaie de se connecter a la dernier session et appelle callbackSuccess si réussi, sinon callbackFail
        // currentUser = new UserInfo("Bob", UserRole.Infirmier);
        //callbackSuccess();

        if (PlayerPrefs.HasKey(keySaveSession))
        {
            try
            {
                currentUser = JsonUtility.FromJson<UserInfo>(PlayerPrefs.GetString(keySaveSession));
            }catch(Exception e)
            {
                Debug.Log("Last session not found");
                currentUser = null;
            }

        }
            
   if(currentUser == null)
        callbackFail();
   else
        callbackSuccess();


    }

    public void Logout()
    {
        PlayerPrefs.DeleteKey(keySaveSession);

        currentUser = null;
        //todo : suprrimer les info de derniere connexion
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


    public UserInfo GetValues()
    {
        return currentUser;
    }



}
