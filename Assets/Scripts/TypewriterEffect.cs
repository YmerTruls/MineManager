using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class TypewriterEffect : MonoBehaviour
{
    private TMP_Text _textBox;

    // For prototyping
    [Header("Test String")]
    [SerializeField] private string testText;

    // Basic Typewriter Functionality
    private int _currentVisibleCharacterIndex;
    private Coroutine _typeWriterCoroutine;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpunctionDelay;

    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 20;
    [SerializeField] private float interpunctionDelay = 0.5f;

    private void Awake()
    {
        _textBox = GetComponent<TMP_Text>();

        _simpleDelay = new WaitForSeconds(1 / charactersPerSecond);
        _interpunctionDelay = new WaitForSeconds(interpunctionDelay);
    }
    void Start()
    {
        SetText(_textBox.text);
    }

    void Update()
    {
   
    }

    public void SetText(string text)
    {
        if (_typeWriterCoroutine != null)
            StopCoroutine(_typeWriterCoroutine);

        _textBox.text = text;
        _textBox.ForceMeshUpdate();

        _textBox.maxVisibleCharacters = 0;
        _currentVisibleCharacterIndex = 0;

        _typeWriterCoroutine = StartCoroutine(Typewriter());
    }

    private IEnumerator Typewriter()
    {
        TMP_TextInfo textInfo = _textBox.textInfo;

        while (_currentVisibleCharacterIndex < textInfo.characterCount)
        {
            char character = textInfo.characterInfo[_currentVisibleCharacterIndex].character;

            _textBox.maxVisibleCharacters++;

            if (character == '?' || character == '.' || character == ',' ||
                character == ';' || character == '!' || character == '-' ||
                character == '\n')
            {
                yield return _interpunctionDelay;
            }
            else
            {
                yield return _simpleDelay;
            }

            _currentVisibleCharacterIndex++;
        }
    }
}
