using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorkerManager workmanager;
    [SerializeField] private CaveNameList mineDropDown;
    private Dictionary<OreData, int> allOre;
    [SerializeField] private QuotaData goalQouta;
    [SerializeField] private QuotaData gatheredResources;

    private void Awake()
    {
         
    }


    public void NextWorker(){
        workmanager.NextWorker();
    }

    public CaveData GetSelectedCave(){
        return mineDropDown.GetSelectedCave();
    }
    public void SendWorker(){
        CaveData cave = GetSelectedCave();
        
    }
    public bool win()
    {
        int succesCount = 0;
        int index = 0;
        foreach (OreData ore in gatheredResources.Ore)
        {
            if (gatheredResources.OreCount[index] >= goalQouta.OreCount[index])
            {
                succesCount++;
            }
            index++;
        }
        return (succesCount == goalQouta.Ore.Count);
        
        
    }
}
