using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    public WorkerData activeWorker;
    public DialogueManager dialogueManager;
    [Header("Scene refs")]
    [SerializeField] private GameObject nextButton;
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

    public WorkerData GetActiveWorker() => activeWorker;
    public void NextWorker()
    {
        if (queue.Count == 0)
        {
            ClearWorker();
            return;
        }

        WorkerData next = queue.Dequeue();

        SetWorker(next);
        dialogueManager.ShowDialogue(next.dialog);
        nextButton.SetActive(false);
    }

    public void SetWorker(WorkerData worker)
    {
        view.Show(worker);
        activeWorker = worker;

    }

    public void ClearWorker()
    {
        view.Hide();
        activeWorker = null;
    }
    public void SendWorker(CaveData cave)
    {
        

    }
}

