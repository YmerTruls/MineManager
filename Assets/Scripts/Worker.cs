using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Worker : MonoBehaviour
{
    //public Sprite portraitSprite;
    private SpriteRenderer spriteRenderer;
    public WorkerData workerdata;

    public void Show(WorkerData data)
    {
        spriteRenderer.sprite = data.portrait;
    }

    public void Hide()
    {
        spriteRenderer.sprite = null;
    }
}
