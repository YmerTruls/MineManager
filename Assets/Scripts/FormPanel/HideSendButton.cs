using UnityEngine;

public class HideSendButton : MonoBehaviour
{
    [SerializeField] private WorkerManager workerManager;
    [SerializeField] private GameObject target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void ToggleButtonActive()
    {
        if (workerManager.GetActiveWorker() == null)
        {
            target.SetActive(false);
        } 
        else
        {
            target.SetActive(true);
        }
    }

}
