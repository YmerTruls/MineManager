using UnityEngine;

public class BlinkingOutline : MonoBehaviour
{
    [SerializeField] private GameObject outline;
    [SerializeField] private float speed = 0.8f;


    // Update is called once per frame
    void Update()
    {
        float uptime = Time.time;

        if ((int)(uptime * speed) % 2 == 1)
        {
            outline.SetActive(false);
        }
        else
        {
            outline.SetActive(true);
        }
    }
}
