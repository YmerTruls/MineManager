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
    [SerializeField] private GameObject endDayButton;

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

        WorkerData next = queue.Dequeue();

        SetWorker(next);
        nextButton.SetActive(false);
        dialogueManager.ShowDialogue(next.dialog);
    }

    public void SetWorker(WorkerData worker)
    {
        view.Show(worker);
        activeWorker = worker;

    }

    public void ClearWorker()
    {
        if (queue.Count == 0)
        {
            view.Hide();
            nextButton.SetActive(false);
            endDayButton.SetActive(true);
            return;
        }
        view.Hide();
        activeWorker = null;
        nextButton.SetActive(true);
    }
}

