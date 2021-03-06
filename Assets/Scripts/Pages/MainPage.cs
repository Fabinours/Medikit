﻿using Newtonsoft.Json.Linq;
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

    public void OpenConectPanel()
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
        else
        {
            Popup.Log("Il n'y a pas de connexion internet et vous ne vous êtes jamais connecté à la plateforme.");
        }
    }





    public void ClickRegister()
    {
        UserInfoScript.Instance.TryRegister(text_id.text, text_pwd.text, OnRegistered, ClickRegister_fail);
    }
    

    void ClickRegister_fail(string why)
    {   
        Popup.Log("Vos identifiants sont incorrectes.");
    }
       

    void OnRegistered()
    {

        OpenPage(navigationPage);
        menuBar.OpenBar();
      
        var user = UserInfoScript.Instance.GetValues();

        Popup.Log("Vous etes loggé en tant que " +user.Role.ToString()+" avec l'identifiant " + user.Identifier);

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
