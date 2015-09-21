using UnityEngine;
using System.Collections;
using System.Xml;

public class Lang : MonoBehaviour{

    public string language= "Italian";
    public Hashtable Strings;


    void Awake()
    {
        setLanguage(Application.dataPath+"/Languages/lang.xml", language);
    }

	public void setLanguage (string path ,string language) {
		XmlDocument xml  = new XmlDocument();
		xml.Load(path);
		
		Strings = new Hashtable();
		XmlNode element = xml.SelectSingleNode("languages").SelectSingleNode(language);
		if (element.HasChildNodes) {
			IEnumerator elemEnum = element.GetEnumerator();
			while (elemEnum.MoveNext()) {
				XmlNode xmlItem = (XmlNode)elemEnum.Current;
                if (xmlItem.Attributes != null)
                {
                    Strings.Add(xmlItem.Attributes["name"].Value, xmlItem.InnerText);
                }
                else
                {
                    Debug.LogError("Not every children of " + language + " have parameter 'name'");
                }
			}
		} else {
			Debug.LogError("The specified language does not exist: " + language);
		}
	}	

	public string getString (string name) {
		if (!Strings.ContainsKey(name)) {
			Debug.LogError("The specified string does not exist: " + name);
			
			return "";
		}
		
		return Strings[name].ToString();
	}
}
