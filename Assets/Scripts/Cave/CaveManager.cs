using System.Collections.Generic;
using UnityEngine;
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
            int amount = (int)((worker.experience * 0.1) + 1) * cave.yield[index];
            resources.Add(ores, amount);
            index++;
        }
        return resources;
    }
}
