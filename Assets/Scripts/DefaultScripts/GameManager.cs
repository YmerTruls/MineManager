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
    [SerializeField] private List<QuotaData> goalQuota;
    [SerializeField] private DailyMessageManager DailyMessage;
    [SerializeField] private List<DailyMessageData> DataMessage;
    private int daycount;

    private void Awake()
    {
        PlayerPrefs.SetInt("day", 0);
        daycount = PlayerPrefs.GetInt("day");
        caveManager = new CaveManager();
        totalResources = new Dictionary<string, int> { };
        foreach (QuotaData quota in goalQuota)
        {
            int currentCount = PlayerPrefs.GetInt("quota" + quota.Ore.OreName);
            PlayerPrefs.SetInt("quota" + quota.Ore.OreName, quota.OreCount + currentCount);
        }
        foreach (DailyMessageData text in DataMessage)
        {
            if (text.day == daycount)
            {   
                Debug.Log("funkar");
                DailyMessage.SetDailyMessage(text.message);
            }
        }
        
 
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
        foreach (var pair in gathered)
        {
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
            }
        }
        //AudioManager.Instance.Play("PickSound");
        workmanager.ClearWorker();
    }
    public bool win()
    {
        foreach (var quota in goalQuota)
        {
            int goal = PlayerPrefs.GetInt("quota" + quota.Ore.OreName);
            int currentResources = totalResources.TryGetValue(quota.Ore.OreName, out int amount) ? amount : 0;
            if (goal > currentResources)
            {
                return false;
            }
        }
        return true;
    }
    public void EndDay()
    {
        if (win())
        {
            Debug.Log("Win!");
            PlayerPrefs.SetString("win", "You fufilled the Quota");
        }
        else
        {
            PlayerPrefs.SetString("win", "You failed to fufill the quota!");
        }
        foreach (var pair in totalResources)
        {
            string key = pair.Key;
            int value = pair.Value;
            PlayerPrefs.SetInt(key, value);
        }
        SceneManager.LoadScene(1);
    }
}
