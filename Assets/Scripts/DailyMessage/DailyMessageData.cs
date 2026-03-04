using UnityEngine;

[CreateAssetMenu(fileName = "DailyMessage", menuName = "DailyMessage")]
public class DailyMessageData : ScriptableObject
{
    [SerializeField] public string message;
    [SerializeField] public int day;
    
}
