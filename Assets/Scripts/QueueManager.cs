using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField] Queue<Worker> WorkerQueue = new Queue<Worker>();


    public void EnQueueWorker(Worker worker) {
        WorkerQueue.Enqueue(worker);
    }

    public Worker DequeueWorker()
    {
       return WorkerQueue.Dequeue();
    }

}
