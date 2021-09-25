using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class XMLManager
{
    AssetResources m_Resources = new AssetResources();

    public SaveDataFile LoadSaveDataFileXML()
    {
        TextAsset saveData = m_Resources.LoadXML("SaveDataFile");

        XmlSerializer serializer = new XmlSerializer(typeof(SaveDataFile));
        using (StringReader reader = new StringReader(saveData.text))
        {
            return serializer.Deserialize(reader) as SaveDataFile;
        }
    }

    public void SaveSaveDataFileToXML(SaveDataFile saveData)
    {
        //try
        //{
            XmlSerializer serializer = new XmlSerializer(typeof(SaveDataFile));
            FileStream stream = new FileStream(Application.dataPath + "/Resources/XML/SaveDataFile.xml", FileMode.Create);
            serializer.Serialize(stream, saveData);
            stream.Close();
        //} catch(Exception e)
        //{

        //}
    }

}
