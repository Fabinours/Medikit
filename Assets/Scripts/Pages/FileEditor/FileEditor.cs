using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;

public class FileEditor : BaseModule
{

    private string path;
    private GameObject container;

    public class XmlReader
    {

        private string xml;
        private string[] lines;
        private int currentLineIndex;
        private GameObject container;

        public XmlReader(string xml, GameObject container)
        {
            this.xml = xml;
            string[] separator = { "\n" };
            lines = xml.Split(separator, System.StringSplitOptions.None);
            currentLineIndex = 1;
            this.container = container;
        }

        private string[] xmlFields()
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
                InputField inputField = container.transform.Find("Fields").Find(field[1]).GetComponent<InputField>();
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

        private Dictionary<string, string> nextItem()
        {
            Dictionary<string, string> item = new Dictionary<string, string>();

            Regex fieldLine = new Regex("<.*>.*<.*>");
            Regex endLine = new Regex("^(</.*>)");

            while (!endLine.IsMatch(lines[currentLineIndex]))
            {
                if (fieldLine.IsMatch(lines[currentLineIndex]))
                {
                    string[] field = xmlFields();
                    item.Add(field[1], field[2]);
                }
                currentLineIndex++;
            }
            currentLineIndex++;
            return item;
        }

        private bool finished()
        {
            if (currentLineIndex > lines.Length - 2)
            {
                return true;
            }
            return false;
        }
    }

    public class XmlWriter
    {

        private string path;
        private GameObject container;

        public XmlWriter(string path, GameObject container)
        {
            this.path = path;
            this.container = container;
        }

        public string generate()
        {
            string res = "<?xml version='1.0' encoding='UTF - 8'?>\n";
            for (int i = 0; i < container.transform.Find("Fields").childCount; i++)
            {
                InputField inputField = container.transform.Find("Fields").GetChild(i).GetComponent<InputField>();
                if (inputField.text=="")
                {
                    return "false";
                }
                res = string.Concat(res, "<"+inputField.name+">"+inputField.text+ "</" + inputField.name + ">\n");

            }
            for (int i = 0; i < container.transform.Find("Scroll View").Find("Viewport").Find("Content").childCount; i++)
            {
                if (container.transform.Find("Scroll View").Find("Viewport").Find("Content").GetChild(i).name=="Model(Clone)")
                {
                    res = string.Concat(res, "<Item>\n");
                    GameObject item = container.transform.Find("Scroll View").Find("Viewport").Find("Content").GetChild(i).gameObject;

                    for (int j = 0; j < item.transform.Find("Fields").childCount; j++)
                    {
                        InputField inputField = item.transform.Find("Fields").GetChild(j).GetComponent<InputField>();
                        if (inputField.text == "")
                        {
                            return "false";
                        }
                        res = string.Concat(res, "\t<" + inputField.name + ">" + inputField.text + "</" + inputField.name + ">\n");
                    }
                    res = string.Concat(res, "</Item>\n");
                }
            }
            return res;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //LoadFile(".xml", true, "0", "Ordonnance",false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadFile(string path, bool edition, string idDoc, string typoDoc, bool creation)
    {
        if (!creation)
        {
            this.path = path;
            if (path.Substring(path.LastIndexOf('.') + 1) == "xml" || path == null)
            {
                if (path != null)
                {
                    string xml;
                    try
                    {
                        //string xml=StorageServer.Get(path);
                        xml = "<?xml version='1.0' encoding='UTF - 8'?>\n<TitleField>Mon ordonnance</TitleField>\n<Item>\n\t<Medicament>Doliprane</Medicament>\n\t<Duree>2</Duree>\n\t<Frequence>1</Frequence>\n\t<Posologie>1</Posologie>\n\t<TimeCode>A</TimeCode>\n</Item><Item>\n\t<Medicament>Ibuprofène</Medicament>\n\t<Duree>2</Duree>\n\t<Frequence>1</Frequence>\n\t<Posologie>1</Posologie>\n\t<TimeCode>A</TimeCode>\n</Item>";
                    }
                    catch (System.Exception e)
                    {
                        throw e;
                    }

                    //Ouverture de la bonne page en fonction de la typologie
                    OpenPage(transform.Find(typoDoc).gameObject);
                    GameObject container = currentPage.transform.Find("Redact").Find("Margin").gameObject;

                    //autocomplete
                    XmlReader xmlReader = new XmlReader(xml, container);

                    xmlReader.run();
                    this.container = container;
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
        else
        {
            //Reset page précédente
            OpenPage(transform.Find(typoDoc).gameObject);
            GameObject container = currentPage.transform.Find("Redact").Find("Margin").gameObject;
            this.path = null;
        }

    }

    public bool Save()
    {
        bool fieldsComplete = true;

        XmlWriter xmlWriter = new XmlWriter(path, container);
        string xml = xmlWriter.generate();
        if (xml == "false")
        {
            fieldsComplete = false;
        }

        if (!fieldsComplete)
        {
            //print msg "Champs nécessaires à remplir"
            return false; 
        }

        if (path != null)
        {
            Debug.Log(xml);
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

    public void SaveButton()
    {
        Save();
    }

    public bool Send()
    {
        return false;
    }

    public override void OnClose()
    {
        base.OnClose();
        Save();
    }

    public void AddFile()
    {

    }

    public void AddParam()
    {

    }
}
