using System.Collections;
using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WorkerView : MonoBehaviour
{   
    [SerializeField] float steps = 6f;
    [SerializeField] float travelTime = 2f;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Hide();
    }

    public void Show(WorkerData data)
    {   
        spriteRenderer.sprite = data != null ? data.portrait : null;
        spriteRenderer.enabled = (data != null && data.portrait != null);
    }

    public void Hide()
    {
        spriteRenderer.sprite = null;
        spriteRenderer.enabled = false;
    }

    private float walkFunction(float time)
    {
        time = time - 1;
        return (float)(Math.Abs(Math.Cos((double)(Math.PI * steps * time))) - 1)/100;
    }

    public IEnumerator CharacterMovement(Vector2 start, Vector2 end)
    {
        transform.position = start;

        float time = 0.0f;

        Vector3 pos = transform.position;        

        while (time <= travelTime)
        {   
            time += Time.deltaTime;
            yield return null;

            pos.x = (travelTime - time)/ travelTime * start.x + (time)/ travelTime * end.x;
            pos.y = (travelTime - time)/ travelTime * start.y + (time)/ travelTime * end.y + 5 * walkFunction(time / travelTime);

            transform.position = pos;
        }

        transform.position = end;
    }
}


