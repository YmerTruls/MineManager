using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SaveObject : MonoBehaviour
{
    public static SaveObject Instance;

    public List<string> MessageList = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
