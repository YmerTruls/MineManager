using UnityEngine;

public class WorkerManager : MonoBehaviour
{   

    public Worker view;

    public WorkerData worker;

    public void SetWorker(WorkerData worker)
    {
        view.Show(worker);
    }

    public void ClearWorker()
    {
        view.Hide();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetWorker(worker);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ClearWorker();
        }
    }
}
