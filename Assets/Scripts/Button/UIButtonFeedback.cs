using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public float pressOffset = 10f;

    private RectTransform rectTransform;
    private Vector2 originalPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPos + new Vector2(0, pressOffset);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPos - new Vector2(0, pressOffset);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rectTransform.anchoredPosition = originalPos;
    }
}