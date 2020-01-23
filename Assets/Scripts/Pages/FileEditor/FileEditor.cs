using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileEditor : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFile(string path, bool edition, string idDoc)
    {
        if (path.Substring(path.LastIndexOf('.') + 1, path.Length) == "xml")
        {
            try
            {
                //StorageServer.Get(path);
            }
            catch (System.Exception e)
            {
                throw e;
            }

            if (edition)
            {
                //register idDoc
                //activate field modification
            }
            else
            {
                //desactivate field modification
            }
            //autocomplete
        }
        else
        {
            if (edition)
            {
                throw new System.Exception("Edition impossible");
            }
            else
            {
                //print as an image
            }
        }
    }

    public bool Save()
    {
        bool fieldsComplete=false;
        string path="";

        if (fieldsComplete)
        {
            //new XML()
            //XML.generate
            if (path=="")
            {
                try
                {
                    //StorageServer.Replace(path,XML.toString);
                }
                catch (System.Exception e)
                {

                    throw e;
                }
            }
            else
            {
                try
                {
                    //StorageServer.Create(currentDmpPath+title,XML.toString);
                    //DatabaseManager.CreateDocument();
                }
                catch (System.Exception e)
                {
                    //undo creation
                    throw e;
                }
            }

            //print msg "Enregistrement effectué"
            return true;
        }
        else
        {
            //print msg "Champs nécessaires à remplir"
            return false;
        }
    }

    public bool Send()
    {
        return false;
    }

    public void OnApplicationQuit()
    {
        
    }

    public void AddFile()
    {

    }

    public void AddParam()
    {

    }
}
