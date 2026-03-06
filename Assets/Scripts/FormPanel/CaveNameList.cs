using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CaveNameList : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    private List<CaveData> Caves = new List<CaveData>();

    private void Awake()
    {
        
    }

    public CaveData GetSelectedCave() { return Caves[dropdown.value]; }

    public void addCave(CaveData cave)
    {
        Caves.Add(cave);
        dropdown.ClearOptions();
        var names = new List<string>();
        foreach (var w in Caves) names.Add(w.CaveName);
        dropdown.AddOptions(names);
    }

    public void OnValueChanged()
    {
        AudioManager.Instance.Play("WritingSound");
    }

    public void OnClick()
    {
        AudioManager.Instance.Play("ClickSound");
    }
}
