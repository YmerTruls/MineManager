using UnityEngine;

public class DoneButton : MonoBehaviour
{
    public GameObject worker;
    [SerializeField] private GameObject panel;

    private void Awake()
    {
        worker = GameObject.Find("WorkerManager");
    }
    public void onClick()
    {
        
        panel.SetActive(false);
    }

}
