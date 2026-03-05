using System.Collections;
using UnityEditor.UI;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WorkerView : MonoBehaviour
{
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

    public IEnumerator CharacterMovement(Vector2 start, Vector2 end)
    {
        transform.position = start;

        float time = 0.0f;

        while (true)
        {
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = end;
    }
}


