using System.Collections.Generic;
using UnityEngine;

public class WorkerManager : MonoBehaviour
{
    [Header("Scene refs")]
    [SerializeField] private WorkerView view;
    [SerializeField] private Transform workerObject;
    [SerializeField] private Camera cam;

    [Header("Queue")]
    [SerializeField] private List<WorkerData> initialQueue = new List<WorkerData>();

    [Header("Placement")]
    [SerializeField] private float distanceInFront = 2f;
    [SerializeField] private float heightOffset = 0f;
    [SerializeField] private bool faceCamera = true;

    private Queue<WorkerData> queue;

    private void Awake()
    {
        cam = Camera.main;
        workerObject = view.transform;

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

        MoveWorkerInFrontOfCamera();
        SetWorker(next);
    }

    private void MoveWorkerInFrontOfCamera()
    {
        if (workerObject == null) return;

        Vector3 targetPos =
            cam.transform.position +
            cam.transform.forward * distanceInFront +
            Vector3.up * heightOffset;

        workerObject.position = targetPos;

        if (faceCamera)
        {
            Vector3 dir = cam.transform.position - workerObject.position;
            dir.y = 0f;
            if (dir.sqrMagnitude > 0.0001f)
                workerObject.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
        }
    }

    public void SetWorker(WorkerData worker)
    {
        view.Show(worker);
    }

    public void ClearWorker()
    {
        view.Hide();
    }
}

