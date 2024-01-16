using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSaves : MonoBehaviour{

    public static TMPro.TMP_Dropdown WorldSavesDropdown; 

    void Awake(){
        WorldSavesDropdown = GameObject.Find("WorldSaves").GetComponent<TMP_Dropdown>();
        UpdateLoadFiles();
    }



    public static void SaveGame(){
        Save curSave = new Save();
        curSave.playerSeed = PlayerPrefs.GetString("playerSeed");
        curSave.worldName = PlayerPrefs.GetString("worldName");
        curSave.worldSize = PlayerPrefs.GetInt("worldSize");
        curSave.PlayerHealth = PlayerHealth.health;
        curSave.timeElapsed = Time.frameCount;
        
        curSave.worldCurrent = WorldGenerator.map;

        string GameSave = JsonConvert.SerializeObject(curSave, Formatting.Indented);
        string GameName = "World";
        if (PlayerPrefs.GetString("worldName") != ""){
            GameName = PlayerPrefs.GetString("worldName");
        }

        File.WriteAllText(Application.persistentDataPath + "/"+GameName+".json", GameSave);
        print(Application.persistentDataPath + "/"+GameName+".json");
        print("SAVED");
    }

    public static void LoadFromSave(string curWorldName = ""){
        var worldName = "";
        try{
            var files = GetAllSaves();
            worldName = files[WorldSavesDropdown.value];
        }
        catch{worldName = curWorldName;}
        string filePath = (Application.persistentDataPath + "/"+worldName+".json");
        string json = File.ReadAllText(filePath);
        Save loadedSave = JsonConvert.DeserializeObject<Save>(json);

        if (loadedSave != null) {
            PlayerPrefs.SetInt("fromFile?",1);
            PlayerPrefs.SetInt("worldSize",loadedSave.worldSize);
            PlayerPrefs.SetString("playerSeed", loadedSave.playerSeed);
            PlayerPrefs.SetString("worldName", loadedSave.worldName);
            PlayerHealth.health = loadedSave.PlayerHealth;
            WorldGenerator.map = loadedSave.worldCurrent;
        

            print("LOADED");
            SceneLoader.LoadScene("Game");
        }
        print("ERROR SAVE NOT FOUND");
    }

    public static List<string> GetAllSaves() {
        var Saves = new List<string>();
        string filePath = Application.persistentDataPath;
        DirectoryInfo info = new DirectoryInfo(filePath);
        FileInfo[] fileInfo = info.GetFiles(); // Get all files in the directory

        foreach (FileInfo file in fileInfo) { 
            string fileName = Path.GetFileNameWithoutExtension(file.Name);
            Saves.Add(fileName);
        }
        print(Saves);
        return Saves;
    }

    public void UpdateLoadFiles(){
        var files = GetAllSaves();
        print("LOOKING");
        print(GameObject.Find("WorldSaves"));
        WorldSavesDropdown.ClearOptions();
        WorldSavesDropdown.AddOptions(files);
        WorldSavesDropdown.value = 1;
        WorldSavesDropdown.RefreshShownValue();
    }

    
}

[System.Serializable]
public class Save {
    public string worldName;
    public string playerSeed;
    public int worldSize;
    public float timeElapsed = 0;
    public float PlayerHealth;
    public int[,] worldCurrent;
}
