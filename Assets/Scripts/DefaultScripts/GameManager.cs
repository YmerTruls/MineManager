using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private WorkerManager workmanager;
    [SerializeField] private CaveNameList mineDropDown;
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

        return false;
    }
}
