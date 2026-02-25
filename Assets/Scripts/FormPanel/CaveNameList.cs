using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaveNameList : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private List<CaveData> Caves;

    private void Awake()
    {
        dropdown.ClearOptions();
        var names = new List<string>();
        foreach (var w in Caves) names.Add(w.CaveName);
        dropdown.AddOptions(names);
    }

    public CaveData GetSelectedCave() { return Caves[dropdown.value]; }
}
