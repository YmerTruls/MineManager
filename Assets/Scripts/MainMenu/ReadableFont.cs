using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TMP_Text))]
public class ReadableFont : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Toggle toggle;

    public static ReadableFont Instance;

    public TMP_FontAsset pixelFont;
    public TMP_FontAsset readableFont;

    private bool usePixel;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void ApplyFont()
    {
        TMP_Text[] texts = FindObjectsOfType<TMP_Text>(true);

        foreach (var t in texts)
        {
            if (usePixel)
            {
                t.font = pixelFont;
                t.fontSize = 12;
            }
            else
            {
                t.font = readableFont;
                t.fontSize = 10;
            }

        }

        if (!usePixel)
        {
            if (SceneManager.GetActiveScene().name == "GameScene")
            {
                GameObject.Find("FormCanvas").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            }
            else if (SceneManager.GetActiveScene().name == "EndOfDayScreen")
            {
                 GameObject.Find("EndOfDayCanvas").GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
            }
        }
    }

    public void ToggleReadableFont(bool value)
    {
        usePixel = value;
        ApplyFont();
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ApplyFont();
    }
}