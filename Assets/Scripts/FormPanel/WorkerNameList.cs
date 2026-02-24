using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkerNameList : MonoBehaviour
    { 
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private List<WorkerData> workers;

    private void Awake()
    {
        dropdown.ClearOptions();
        var names = new List<string>();
        foreach (var w in workers) names.Add(w.characterName);
        dropdown.AddOptions(names);
    }

    public WorkerData GetSelectedWorker() => workers[dropdown.value];
}

