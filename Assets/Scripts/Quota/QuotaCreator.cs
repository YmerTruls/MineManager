using UnityEngine;

public class QuotaCreator
{
    private QuotaData currentquota;
    //newScriptableObject = ScriptableObject.CreateInstance<MyScriptableObjectType>()
    public QuotaData createQuota(OreData Ore, int OreCount)
    {
        currentquota = ScriptableObject.CreateInstance<QuotaData>();
        currentquota.Ore = Ore;
        currentquota.OreCount = OreCount;

        return currentquota;
    }
}
