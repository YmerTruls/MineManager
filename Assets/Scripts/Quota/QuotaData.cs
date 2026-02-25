using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuotaData", menuName = "Quotas/Quota")]
public class QuotaData : ScriptableObject
{
    public List<OreData> Ore;
    public List<int> OreCount;
}
