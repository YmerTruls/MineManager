using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCaveData", menuName = "Caves/Cave")]
public class CaveData : ScriptableObject
{
    public string CaveName;
    public int CaveId;
    public List<OreData> ResourceType;
    public List<int> yield;
}
