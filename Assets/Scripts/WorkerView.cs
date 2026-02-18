using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class WorkerView : MonoBehaviour
{
    //public Sprite portraitSprite;
    private SpriteRenderer spriteRenderer;

    public void Show(WorkerData data)
    {
        spriteRenderer.sprite = data.portrait;
    }

    public void Hide()
    {
        spriteRenderer.sprite = null;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
