using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWorkerData", menuName = "Workers/Worker")]
public class WorkerData : ScriptableObject
{
    public string characterName;
    public int WorkerId;
    public Sprite portrait;
    public float experience;
    public string dialog;
    public List<DialogData> DialogData;
    public DialogData currentDialog;
    //public Ass default;
}
