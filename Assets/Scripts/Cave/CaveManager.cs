using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaveManager : MonoBehaviour
{
    [SerializeField] public List<CaveData> caves;
    private CaveNameList cave;

    private void Awake()
    {
        cave = FindFirstObjectByType<CaveNameList>();
    }

    public void RecieveWorker()
    {

    }
}
