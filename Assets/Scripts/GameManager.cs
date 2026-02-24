using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorkerManager workmanager;
    [SerializeField] private CaveNameList mineDropDown;
    [SerializeField] private List<OreData> allOre;
    private Dictionary<OreData, int> Resources;

    private void Awake()
    {
     foreach (OreData ore in allOre)
        {
            if (ore == null) continue;

            if (!Resources.ContainsKey(ore))
            {
                Resources.Add(ore, 0);
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
        CaveData cave = GetSelectedCave();
        
    }
}
