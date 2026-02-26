using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorkerManager workmanager;
    [SerializeField] private CaveNameList mineDropDown;
    private Dictionary<OreData, int> totalResources;
    private WorkerData currentWorker;
    private CaveManager caveManager;
    [SerializeField] private QuotaData goalQuota;

    private void Awake()
    {
        caveManager = new CaveManager();
        totalResources = new Dictionary<OreData, int> { };
 
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
            if (totalResources.ContainsKey(pair.Key))
            {
                totalResources[pair.Key] += pair.Value;
            }
            else
            {
                totalResources.Add(pair.Key, pair.Value);
            }
            workmanager.ClearWorker();
        }



    }
    public bool win()
    {
       if (totalResources.ContainsKey(goalQuota.Ore) && totalResources[goalQuota.Ore] >= goalQuota.OreCount){
            return true;
        }
        return false;
    }
    public void EndDay()
    {
        if (win())
        {

        }
    }
}
