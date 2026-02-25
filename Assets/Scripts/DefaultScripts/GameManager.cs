using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorkerManager workmanager;
    [SerializeField] private CaveNameList mineDropDown;
    [SerializeField] private List<OreData> allOre;
    [SerializeField] private QuotaData qouta;

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

    public QuotaData getQuota()
    {
        return null;
    }
}
