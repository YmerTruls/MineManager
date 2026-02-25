using UnityEngine;

public class DoneButton : MonoBehaviour
{
    [SerializeField] private WorkerManager worker;
    [SerializeField] private GameObject panel;
    [SerializeField] private DialogueBox db;
    [SerializeField] private GameObject nextButton;
    //[SerializeField] private CaveNameList cavelist;
    //public CaveData cave;


    private void Awake()
    {
        //worker = FindFirstObjectByType<WorkerManager>();

    }
    public void onClick()
    {
        panel.SetActive(false);
        if (worker.GetActiveWorker() != null) {
            //cave = cavelist.GetSelectedCave();
            //worker.SendWorker(cave);
            worker.ClearWorker();
            db.HideDialogue();
            nextButton.SetActive(true);

        }
        else {
            return;
        }
    }

}
