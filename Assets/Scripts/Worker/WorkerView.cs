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
}


