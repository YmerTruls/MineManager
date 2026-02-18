using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{   
    
    private QueueManager Queue = new QueueManager();
    private WorkerManager WorkerManager = new WorkerManager();

    void Start()
    {

    }
    public void SceneChanger(){

    }

    public void ManageWorkers(){
        Worker currentWorker = Queue.DequeueWorker();
        
    }

    public void ShaftManager(){

    }

    public void Form(){

    }

    public void DailyMessage() {
    }
}

