using UnityEngine;

[CreateAssetMenu(fileName = "DailyMessage", menuName = "DailyMessage")]
public class DailyMessage : ScriptableObject
{
    [SerializeField] public string message;
    [SerializeField] public int day;
    
}
