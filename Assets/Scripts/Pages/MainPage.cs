using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPage : BaseModule
{
    [SerializeField]
    GameObject connexionPage;

    [SerializeField]
    GameObject navigationPage;

    
    MenuBar menuBar;

    [SerializeField]
    InputField text_id;
    [SerializeField]
    InputField text_pwd;




    [System.Serializable]
   private class KeyValueUserGameObject
    {
        public UserRole Role { get => role; }
        [SerializeField]
        UserRole role;
        public GameObject[] Objs { get => objs; }
        [SerializeField]
        GameObject[] objs;
    }

    [SerializeField]
    Transform buttonParents;

    [SerializeField]
    KeyValueUserGameObject[] activeByRole;//parce que les dicos sont pas editables dans l'editeur


    private void Start()
    {
        menuBar = GameObject.FindObjectOfType<MenuBar>();
    }

    public void OpenConnetPannel()
    {
        UserInfoScript.Instance.RegisterLastSession(RegisterLastSession_Success, RegisterLastSession_Fail);
    }
    void RegisterLastSession_Success()
    {
        OnRegistered();
    }

    void RegisterLastSession_Fail()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)//si il y a de la coo
            OpenPage(connexionPage);

    }





    public void ClickRegister()
    {
        UserInfoScript.Instance.TryRegister(text_id.text, text_pwd.text, OnRegistered, ClickRegister_fail);
    }
    

    void ClickRegister_fail(string why)
    {
   
        Popup.Log("Register error :" +why);
    }
       

    void OnRegistered()
    {

        OpenPage(navigationPage);
        menuBar.OpenBar();
      
        var user = UserInfoScript.Instance.GetValues();

        Popup.Log("Vous etes loggé en tant que " +user.Role.ToString()+" avec l'identifiant " + user.Id);

        foreach (Transform t in buttonParents)
            t.gameObject.SetActive(false);

        foreach (var e in activeByRole)
        {
            if(e.Role == user.Role)
            {
                foreach (var o in e.Objs)
                    o.SetActive(true);

                 break;
            }
        }

        menuBar.UpdateButtons();


    }



}
