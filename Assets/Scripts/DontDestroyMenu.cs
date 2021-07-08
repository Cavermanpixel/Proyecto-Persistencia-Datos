using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DontDestroyMenu : MonoBehaviour
{
    public static DontDestroyMenu Instance;
    //CAMBIAR A RECORDS
    public List<records> nuevosRecords = new List<records>();

    public string namePlayer; //Declaracion de una variable nombre para guardar el parametro de nombre y pasarlo a la Scena del Juego
    public int puntos;
    public string bestName;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            puntos = 0;
        }
        LoadRecord();
        LoadLastRecord();

    }

    //Data para guardar
    [System.Serializable]
    class SaveData
    {
        public int bestRecordData;
        public string bestRecordNameData;
        public string namePlayerData;
        public List<records> salvarRecord = new List<records>();
    }

  
    

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.bestRecordData = puntos;
        data.bestRecordNameData = bestName;
        data.namePlayerData = namePlayer;
        


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);


    }

    public void SaveLastRecord()
    {
        SaveData dataR = new SaveData();
        dataR.salvarRecord = nuevosRecords;
        if (dataR.salvarRecord.Count > 5)
        {
            dataR.salvarRecord.Sort();
            dataR.salvarRecord.Reverse();
            dataR.salvarRecord.RemoveAt(5);
        }
        else
        {
            dataR.salvarRecord.Sort();
            dataR.salvarRecord.Reverse();
        }
        
        foreach (records aPart in dataR.salvarRecord)
        {
            Debug.Log(aPart);
        }

        string json = JsonUtility.ToJson(dataR);

        File.WriteAllText(Application.persistentDataPath + "/savefile2.json", json);
    }
    public void LoadLastRecord()
    {
        string path = Application.persistentDataPath + "/savefile2.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

           nuevosRecords = data.salvarRecord;
        }
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            puntos = data.bestRecordData;
            bestName = data.bestRecordNameData;
            namePlayer = data.namePlayerData;
            //nuevosRecords = data.salvarRecord;
        }
    }
    // Start is called before the first frame update

}
