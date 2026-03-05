using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuotaData", menuName = "Quotas/Quota")]
public class QuotaData : ScriptableObject
{
    public OreData Ore;
    public int OreCount;
    public int ID;
}
