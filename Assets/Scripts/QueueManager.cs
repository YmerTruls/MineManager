using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    public Queue<WorkerInterface> WorkerQueue = new Queue<WorkerInterface>();


    public void EnQueueWorker(WorkerInterface worker) {
        WorkerQueue.Enqueue(worker);
    }

    public WorkerInterface DequeueWorker()
    {
       return WorkerQueue.Dequeue();
    }

}
