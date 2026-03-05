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
    private Queue<WorkerData> queue = new Queue<WorkerData>();

    private void Awake()
    {

    }

    private void Start()
    {
        ClearWorker();
    }

    public WorkerData GetActiveWorker() => activeWorker;
    public void NextWorker()
    {   

        // Set new Worker
        WorkerData next = queue.Dequeue();
        SetWorker(next);
        nextButton.SetActive(false);

        // Worker Enter
        dialogueManager.ShowDialogue(next.dialog);
    }

    public void SetWorker(WorkerData worker)
    {
        view.Show(worker);
        activeWorker = worker;

    }

    public void ClearWorker()
    {
        dialogueManager.HideDialog();
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
    public void AddWorker(WorkerData worker)
    {
        queue.Enqueue(worker);
    }
}

