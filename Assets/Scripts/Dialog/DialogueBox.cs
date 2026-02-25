using System.Collections;
using TMPro;
using UnityEngine;


public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBox;

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
        _simpleDelay = new WaitForSeconds(1f / charactersPerSecond);
        _interpunctionDelay = new WaitForSeconds(interpunctionDelay);
    }
    void Start()
    {
        //SetActive(false); ?? 
        //SetText(_textBox.text);
    }

    void Update()
    {
   
    }

    public void HideDialogue()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        if (_typeWriterCoroutine != null)
            StopCoroutine(_typeWriterCoroutine);

        gameObject.SetActive(true);
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
