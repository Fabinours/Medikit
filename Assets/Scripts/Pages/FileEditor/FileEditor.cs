using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class FileEditor : BaseModule
{

    public class XmlReader
    {

        private string xml;
        private string[] lines;
        private int currentLineIndex;
        private GameObject container;

        public XmlReader(string xml,GameObject container)
        {
            this.xml = xml;
            string[] separator = { "\n" };
            lines = xml.Split(separator,System.StringSplitOptions.None);
            currentLineIndex = 1;
            this.container = container;
        }

        public string[] xmlFields()
        {
            lines[currentLineIndex].Trim();
            string[] separator = { "<", ">" };
            string[] field = lines[currentLineIndex].Split(separator, System.StringSplitOptions.None);
            return field;
        }

        public void run()
        {

            Regex fieldLine = new Regex("<.*>.*<.*>");
            while (fieldLine.IsMatch(lines[currentLineIndex]))
            {
                string[] field = xmlFields();
                InputField inputField = container.transform.Find(field[1]).GetComponent<InputField>();
                inputField.SetTextWithoutNotify(field[2]);
                currentLineIndex++;
            }
            GameObject content = container.transform.Find("Scroll View").Find("Viewport").Find("Content").gameObject;
            while (!finished())
            {
                content.GetComponent<ScrollDisplay>().addContent();
                GameObject itemObject = content.GetComponent<ScrollDisplay>().lastInstance;
                Dictionary<string, string> item = nextItem();
                foreach (KeyValuePair<string, string> entry in item)
                {
                    InputField inputField = itemObject.transform.Find("Fields").Find(entry.Key).GetComponent<InputField>();
                    inputField.SetTextWithoutNotify(entry.Value);
                }
            }
        }

        public Dictionary<string,string> nextItem()
        {
            Dictionary<string, string> item = new Dictionary<string,string>();

            Regex fieldLine = new Regex("<.*>.*<.*>");
            Regex endLine = new Regex("^(</.*>)");

            while (!endLine.IsMatch(lines[currentLineIndex]))
            {
                if (fieldLine.IsMatch(lines[currentLineIndex]))
                {
                    string[] field = xmlFields();
                    item.Add(field[1],field[2]);
                }
                currentLineIndex++;
            }
            currentLineIndex++;
            return item;
        }

        public bool finished()
        {
            if (currentLineIndex>lines.Length-2)
            {
                return true;
            }
            return false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //LoadFile(".xml", true, "0", "Ordonnance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFile(string path, bool edition, string idDoc,string typoDoc)
    {
        if (path.Substring(path.LastIndexOf('.') + 1) == "xml" || path==null)
        {
            if (path!=null)
            {
                string xml;
                try
                {
                    //string xml=StorageServer.Get(path);
                    xml = "<?xml version='1.0' encoding='UTF - 8'?>\n<TitleField>Mon ordonnance</TitleField>\n<Traitement>\n<Medicament>Doliprane</Medicament>\n<Duree>2</Duree>\n<Frequence>1</Frequence>\n<Posologie>1</Posologie>\n<TimeCode>A</TimeCode>\n</Traitement><Traitement>\n<Medicament>Ibuprofène</Medicament>\n<Duree>2</Duree>\n<Frequence>1</Frequence>\n<Posologie>1</Posologie>\n<TimeCode>A</TimeCode>\n</Traitement>";
                }
                catch (System.Exception e)
                {
                    throw e;
                }

                //Ouverture de la bonne page en fonction de la typologie
                OpenPage(transform.Find(typoDoc).gameObject);
                GameObject container = currentPage.transform.Find("Redact").Find("Margin").gameObject;
                Text titleField = container.transform.Find("TitleField").Find("Text").GetComponent<Text>();

                //autocomplete
                XmlReader xmlReader = new XmlReader(xml, container);

                xmlReader.run();
            }

            if (edition)
            {
                //register idDoc
                //activate field modification & buttons
            }
            else
            {
                //desactivate field modification & buttons
            }
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
