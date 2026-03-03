using System.Collections;
using TMPro;
using UnityEngine;


public class DialogueBox : MonoBehaviour
{
    [SerializeField] private TMP_Text _textBox;

    // Page info:
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject PreviousButton;
    private int dialogPage = 1;

    // Basic Typewriter Functionality
    private int _currentVisibleCharacterIndex;
    private Coroutine _typeWriterCoroutine;

    private WaitForSeconds _simpleDelay;
    private WaitForSeconds _interpunctionDelay;

    [Header("Typewriter Settings")]
    [SerializeField] private float charactersPerSecond = 40;
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

    private void DisplayPage(int page)
    {
        dialogPage = page;
        _textBox.pageToDisplay = page;

        int pageCount = _textBox.textInfo.pageCount;

        // Show/Hide Buttons
        if (dialogPage == pageCount)
        {
            NextButton.SetActive(false);
        } else
        {
            NextButton.SetActive(true);
        }

        if (dialogPage == 1)
        {
            PreviousButton.SetActive(false);
        }
        else
        {
            PreviousButton.SetActive(true);
        }
    }

    public void NextPage()
    {
        _textBox.ForceMeshUpdate();
        int pageCount = _textBox.textInfo.pageCount;
        if (dialogPage < pageCount)
        {
            DisplayPage(dialogPage + 1);
        }
    }

    public void PreviousPage()
    {
        if (dialogPage > 1)
        {
            DisplayPage(dialogPage - 1);
        }
    }

    public void HideDialogue()
    {
        gameObject.SetActive(false);
    }

    public void SetText(string text)
    {
        DisplayPage(1);

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
