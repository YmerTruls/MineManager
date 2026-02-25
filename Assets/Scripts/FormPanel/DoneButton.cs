using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public WorkerManager worker;
    [SerializeField] private GameObject panel;
    [SerializeField] private CaveNameList cavelist;
    public CaveData cave;


    private void Awake()
    {
        worker = FindFirstObjectByType<WorkerManager>();

    }
    public void onClick()
    {
        panel.SetActive(false);
        if (worker.activeWorker) {
            cave = cavelist.GetSelectedCave();
            worker.SendWorker(cave);
        }
        else {
            return;
        }
    }

}
