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
            PlayerPrefs.SetInt("pref" + worker.characterName, 1);
        }
        return resources;
    }
}
