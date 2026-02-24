using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public bool ActiveWorker;
    [SerializeField] public GameObject nextButton;
    [Header("Scene refs")]
    [SerializeField] private WorkerView view;
    [SerializeField] private CaveManager cavemanager;

    [Header("Queue")]
    [SerializeField] private List<WorkerData> initialQueue = new List<WorkerData>();

    private Queue<WorkerData> queue;

    private void Awake()
    {


        queue = new Queue<WorkerData>(initialQueue);
    }

    private void Start()
    {
        ClearWorker();
    }
    public void NextWorker()
    {
        if (queue.Count == 0)
        {
            ClearWorker();
            return;
        }

        WorkerData next = queue.Dequeue();

        SetWorker(next);
        nextButton.SetActive(false);
    }

    public void SetWorker(WorkerData worker)
    {
        view.Show(worker);
        ActiveWorker = true;

    }

    public void ClearWorker()
    {
        view.Hide();
        ActiveWorker = false;
    }
    public void SendWorker(CaveData cave)
    {
        

    }
}

