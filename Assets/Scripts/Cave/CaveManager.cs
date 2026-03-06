using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CaveManager
{
    private Dictionary<OreData, int> resources;


    public Dictionary<OreData, int> RecieveWorker(WorkerData worker, CaveData cave)
    {
        resources = new Dictionary<OreData, int> { };
        int index = 0;
        foreach (OreData ores in cave.ResourceType)
        {
            int amount = (int)((worker.experience * 0.1 + 1) * cave.yield[index]);
            resources.Add(ores, amount);
            index++;
        }
        
        if (worker.currentDialog.cavePref == cave)
        {
            int CurrentApproval = PlayerPrefs.GetInt(worker.characterName);
            PlayerPrefs.SetInt(worker.characterName, CurrentApproval + 1);
            worker.Approval++;
            worker.pref = true;
            Debug.Log(worker.characterName + " " + worker.pref + "Approval" + worker.Approval);
        }
        else
        {
            worker.pref = false;
            Debug.Log(worker.characterName + " " + worker.pref);
        }
        return resources;
    }
}
