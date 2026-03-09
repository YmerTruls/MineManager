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
    private string quotaCount;
    [SerializeField] private List<WorkerData> AllWorkers;
    [SerializeField] private List<CaveData> AllCaves;

    private void Awake()
    {
        quotaCount = "Quota for today: \n";
        daycount = PlayerPrefs.GetInt("day");
        caveManager = new CaveManager();
        totalResources = new Dictionary<string, int> { };
        foreach (QuotaData quota in goalQuota)
        {
            if (quota.ID == daycount)
            {
                int currentCount = PlayerPrefs.GetInt("quota" + quota.Ore.OreName);
                PlayerPrefs.SetInt("quota" + quota.Ore.OreName, quota.OreCount + currentCount);
                quotaCount += $"{quota.Ore.OreName}: {quota.OreCount}\n";
            }

        }
        foreach (DailyMessageData text in DataMessage)
        {
            if (text.day == daycount)
            {   
                string NewMessage = text.message + " \n" + "M.I.N.E. CORP, Diggin our way to future!\n" + quotaCount;
                DailyMessage.AddAndSetDailyMessage(NewMessage);
            }
        }
        foreach (WorkerData worker in AllWorkers)
        {
            if (worker.WorkerId <= daycount)
            {
                if (!(worker.characterName == "Edvin Hammer" && PlayerPrefs.GetInt("prefEdvin Hammer", 0) > 0))
                {
                    workmanager.AddWorker(worker);
                    Debug.Log(worker.characterName + "  Added");
                }
                foreach(DialogData dialog in worker.DialogData) {
                    if (PlayerPrefs.GetInt("pref" + worker.characterName, 0) == dialog.pref && daycount == dialog.day)
                    {
                        int approval = PlayerPrefs.GetInt(worker.characterName);
                        Debug.Log(PlayerPrefs.GetInt("pref" + worker.characterName, 0) + "  " + worker.characterName);
                        if (approval >= dialog.approval)
                        {
                            worker.dialog = dialog.text;
                            worker.currentDialog = dialog;
                        }
                    }
                }
            }
            PlayerPrefs.SetInt("pref" + worker.characterName, 0);
        }
        foreach (CaveData caves in AllCaves)
        {
            if (caves.CaveId <= daycount)
            {
                mineDropDown.addCave(caves);
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
            PlayerPrefs.SetString("win", "You fufilled the Quota");
            int successcount = PlayerPrefs.GetInt("success");
            PlayerPrefs.SetInt("success", successcount + 1);
        }
        else
        {
            PlayerPrefs.SetString("win", "You failed to fufill the quota!");
            int failcount = PlayerPrefs.GetInt("fail");
            PlayerPrefs.SetInt("fail", failcount + 1);
        }
        foreach (var pair in totalResources)
        {
            string key = pair.Key;
            int value = pair.Value;
            PlayerPrefs.SetInt(key, value);
        }
        SceneManager.LoadScene(2);
    }
}
