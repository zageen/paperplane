using System;
using System.IO;
using UnityEngine;


public class DataManagerDeux : MonoBehaviour {

    public static DataManagerDeux Instance;

    public string path;

    public Data data;
	
	void Awake ()
    {

        Instance = this;
        SetPath();
        Load();
	}

    void SetPath()
    {
        path = Path.Combine(Application.persistentDataPath, "data.json");
    }

    public void Save ()
    {
        SetData();
        SerializeData();

	}


    void SetData()
    {
        if( data == null)
        {
            data = new Data();
        }

        data.index = GameManagerDeux.Instance.index;
    }


    void SerializeData()
    {
        string dataString = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, dataString);
    }

    public void Load()
    {
        if (File.Exists(path))
        {
            DeserializeData();
        }
        else
        {
            data = new Data();
        }

        ExploitData();

    }


    void DeserializeData()
    {
        string loadedString = File.ReadAllText(path);
        data = JsonUtility.FromJson<Data>(loadedString);
    }

    void ExploitData()
    {

        GameManagerDeux.Instance.index = data.index;

    }

    
}
