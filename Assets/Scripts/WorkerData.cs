using UnityEngine;

[CreateAssetMenu(fileName = "NewWorkerData", menuName = "Workers/Worker")]
public class WorkerData : ScriptableObject
{
    public string characterName;
    public int WorkerId;
    public Sprite portrait;
    public int experience;
}
