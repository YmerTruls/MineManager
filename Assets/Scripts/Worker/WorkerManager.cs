using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
        dialogueManager.HideDialog();
        activeWorker = null;
        nextButton.SetActive(true);
    }

    public WorkerData GetActiveWorker() => activeWorker;
    public void NextWorker()
    {
        StartCoroutine(NextWorkerRoutine());
    }

    private IEnumerator NextWorkerRoutine() { 
        
        nextButton.SetActive(false);
        WorkerData next = queue.Dequeue();
        SetWorker(next);


        // Worker Enter
        yield return StartCoroutine(
            view.CharacterMovement(new Vector3(-1.9f, -0.03f, 0), new Vector3(0, -0.03f, 0))
        );

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

        StartCoroutine(ClearWorkerRoutine());
    }

    private IEnumerator ClearWorkerRoutine()
    {
        // Worker Exit
        yield return StartCoroutine(
            view.CharacterMovement(new Vector3(0, -0.03f, 0), new Vector3(1.9f, -0.03f, 0))
        );

        if (queue.Count == 0)
        {
            nextButton.SetActive(false);
            endDayButton.SetActive(true);
        }
        else
        {
            activeWorker = null;
            nextButton.SetActive(true);
        }

    }

    public void AddWorker(WorkerData worker)
    {
        queue.Enqueue(worker);
    }
}

