using UnityEngine;
using TMPro;

public class ReadableFont : MonoBehaviour
{
    //[SerializeField] private UnityEngine.UI.Toggle toggle;

    public static ReadableFont Instance;

    public TMP_FontAsset pixelFont;
    public TMP_FontAsset readableFont;

    //private bool useReadable;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    //public void SetReadableFont(bool value)
    //{
    //    useReadable = value;
    //    ApplyFont();
    //}

    void ApplyFont(bool useReadable)
    {
        TMP_FontAsset fontToUse = useReadable ? readableFont : pixelFont;

        TMP_Text[] texts = FindObjectsOfType<TMP_Text>(true);

        foreach (var t in texts)
        {
            t.font = fontToUse;
        }
    }

    public void ToggleReadableFont(bool useReadable)
    {
        ReadableFont.Instance.ApplyFont(useReadable);
    }
}
