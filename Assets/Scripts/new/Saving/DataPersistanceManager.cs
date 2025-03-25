using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    private GameData gameData;
    public static DataPersistanceManager instance { get; private set; }
    private List<IDataPersistance> dataPersistanceObjects;
    private FileDataHandler dataHandler;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("What the actual fuck. This data is too persistent.");
        }
        instance=this;
    }
    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistanceObjects = findAllDataPersistanceObjects();
        LoadGame();
    }
    public void NewGame(){
        this.gameData=new GameData();
    }
    public void LoadGame(){
        this.gameData=dataHandler.Load();
        if (this.gameData==null)
        {
            Debug.Log("No data dumbass. Starting new game.");
            NewGame();
        }
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.LoadData(gameData);
        }
        Debug.Log("Loaded zone "+gameData.zone);
    }
    public void SaveGame(){
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.SaveData(ref gameData);
        }
        Debug.Log("Saved zone "+gameData.zone);
        dataHandler.Save(gameData);
    }
    private void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistance> findAllDataPersistanceObjects(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}
