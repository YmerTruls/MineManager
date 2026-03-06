using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "Scriptable Dialog/DialogData")]
public class DialogData : ScriptableObject
{
    public int day;
    public string text;
    public int approval;
    public bool pref;
    public CaveData cavePref;
    
}
