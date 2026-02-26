using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorkerManager workmanager;
    [SerializeField] private CaveNameList mineDropDown;
    private Dictionary<string, int> totalResources;
    private WorkerData currentWorker;
    private CaveManager caveManager;
    [SerializeField] private QuotaData goalQuota;

    private void Awake()
    {
        caveManager = new CaveManager();
        totalResources = new Dictionary<string, int> { };
        
        
 
    }

    public void NextWorker(){
        workmanager.NextWorker();
    }

    public CaveData GetSelectedCave(){
        return mineDropDown.GetSelectedCave();
    }
    public void SendWorker(){
        currentWorker = workmanager.GetActiveWorker();
        CaveData cave = GetSelectedCave();
        Dictionary<OreData, int> gathered = caveManager.RecieveWorker(currentWorker, cave);
        foreach (var pair in gathered){
            string key = pair.Key.OreName;
            int value = pair.Value;
            if (totalResources.ContainsKey(key))
            {
                value += totalResources[key];
                totalResources[key] = value;
            }
            else
            {
                totalResources.Add(key, value);
                Debug.Log("Added \"" + key + "\" \"" + value + "\"");
            }
            Debug.Log("GameManager Awake, Instance ID: " + this.GetInstanceID());
        }
        workmanager.ClearWorker();
    }
    public bool win()
    {
        Debug.Log("GameManager Awake, Instance ID: " + this.GetInstanceID());

        Debug.Log(goalQuota.Ore.OreName);
        Debug.Log("Type: " + "Coal".GetType());
        Debug.Log(totalResources["Coal"]);
        if (totalResources[goalQuota.Ore.OreName] >= goalQuota.OreCount){
            return true;
        }
        return false;
    }
    public void EndDay()
    {
        if (win())
        {   
            foreach (var pair in totalResources)
            {
                string key = pair.Key;
                int value = pair.Value;
                PlayerPrefs.SetInt(key, value);
                PlayerPrefs.SetString("win", "You fufilled the Qouta!");
                SceneManager.LoadScene(1);
                
            }
            Debug.Log("You won!");
        }
    }
}
