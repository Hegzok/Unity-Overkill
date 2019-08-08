using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField] private string mainPath = "/game_save/";

    [SerializeField] private List<ScriptableObject> objectsToSave;

    [SerializeField] private bool SaveDefaultBool = false;

    private void Start()
    {
        if (IsSaveFile(mainPath) && !SaveDefaultBool)
        {
            LoadAllDataAtStart();
        }

        if (SaveDefaultBool)
        {
            SaveAllDefault(true);
        }
    }

    public bool IsSaveFile(string path)
    {
        return Directory.Exists(Application.persistentDataPath + path);
    }

    public void SaveGame(ScriptableObject SObject)
    {
        if (!IsSaveFile(mainPath))
        {
            Directory.CreateDirectory(Application.persistentDataPath + mainPath);
        }

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + mainPath + SObject.name + ".bb"); // If saving doesnt work try to change bb to txt

        var json = JsonUtility.ToJson(SObject);
        bf.Serialize(file, json);

        file.Close();
    }

    public void LoadGame(ScriptableObject SObject)
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (!IsSaveFile(mainPath))
        {
            Debug.LogWarning("There is no save folder created");
        }

        if (File.Exists(Application.persistentDataPath + mainPath + SObject.name + ".bb"))
        {
            FileStream file = File.Open(Application.persistentDataPath + mainPath + SObject.name + ".bb", FileMode.Open);

            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), SObject);

            file.Close();
        }
        else
        {
            Debug.LogWarning("Save folder is created but there is no save file for this object");
        }
    }

    public void SaveDefault(bool save, ScriptableObject SObject)
    {
        // Delete whole function after release

        if (save)
        {
            if (!IsSaveFile(mainPath))
            {
                Directory.CreateDirectory(Application.persistentDataPath + mainPath);
            }

            BinaryFormatter bf = new BinaryFormatter();

            FileStream file = File.Create(Application.persistentDataPath + mainPath + SObject.name + "default" + ".bb"); // If saving doesnt work try to change bb to txt

            var json = JsonUtility.ToJson(SObject);
            bf.Serialize(file, json);

            file.Close();
        }
        else
        {
            BinaryFormatter bf = new BinaryFormatter();

            if (!IsSaveFile(mainPath))
            {
                Debug.LogWarning("There is no save folder created");
            }

            if (File.Exists(Application.persistentDataPath + mainPath + SObject.name + "default" + ".bb"))
            {
                FileStream file = File.Open(Application.persistentDataPath + mainPath + SObject.name + "default" + ".bb", FileMode.Open);

                JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), SObject);

                SaveAllData();

                file.Close();
            }
            else
            {
                Debug.LogWarning("Save folder is created but there is no save file for this object");
            }
        }
    }

    public void SaveAllDefault(bool save)
    {
        // Delete whole function after release

        foreach (var SObject in objectsToSave)
        {
            SaveDefault(save, SObject);
        }
    }

    public void SaveAllData()
    {
        foreach (var SObject in objectsToSave)
        {
            SaveGame(SObject);
        }
    }

    public void LoadAllDataAtStart()
    {
        foreach (var SObject in objectsToSave)
        {
            LoadGame(SObject);
        }
    }
}
