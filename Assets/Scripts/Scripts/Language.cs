using UnityEngine;
using System.Collections;
using System.Xml;

public static class Language {

    public static string language;
    public static Hashtable Strings;


    public static void Initialize(string language)
    {
		setLanguage("lang", language);
    }

	public static void setLanguage (string path ,string language) {

		TextAsset textAsset = Resources.Load(path, typeof(TextAsset)) as TextAsset;

		XmlDocument xml  = new XmlDocument();
		xml.LoadXml(textAsset.text);
		
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

	public static string getString (string name) {
		if (!Strings.ContainsKey(name)) {
			Debug.LogError("The specified string does not exist: " + name);
			
			return "";
		}
		
		return Strings[name].ToString();
	}
}
