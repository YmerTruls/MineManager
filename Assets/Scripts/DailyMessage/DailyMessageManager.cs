using UnityEngine;
using TMPro;

public class DailyMessageManager : MonoBehaviour
{
    private int day;
    public TMP_Text DailyMessageText;

    // Page info:
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject PreviousButton;
    private int dialogPage = 1;

    public void Awake()
    {
        

    }

    public void SetDailyMessage(string message)
    {
        DailyMessageText.SetText(message);
        dialogPage = 1;
        DisplayPage(dialogPage);
    }

    private void DisplayPage(int page)
    {
        DailyMessageText.ForceMeshUpdate();

        dialogPage = page;
        DailyMessageText.pageToDisplay = page;


        TMP_TextInfo textInfo = DailyMessageText.textInfo;
        int pageCount = textInfo.pageCount;
        int pageLastCharIndex = textInfo.pageInfo[dialogPage - 1].lastCharacterIndex;

        Debug.Log("DM " + DailyMessageText.maxVisibleCharacters + ", " + pageLastCharIndex);

        // Show/Hide Buttons
        if (dialogPage == pageCount && DailyMessageText.maxVisibleCharacters >= pageLastCharIndex)
        {
            SetButtonActive(NextButton, false);
        }
        else
        {
            SetButtonActive(NextButton, true);
        }

        if (dialogPage == 1)
        {
            SetButtonActive(PreviousButton, false);
        }
        else
        {
            SetButtonActive(PreviousButton, true);
        }
    }

    private void SetButtonActive(GameObject button, bool active)
    {
        if (button != null)
        {
            button.SetActive(active);
        }
    }

    public void NextPage()
    {
        DailyMessageText.ForceMeshUpdate();

        TMP_TextInfo textInfo = DailyMessageText.textInfo;
        int pageCount = textInfo.pageCount;
        //int pageLastCharIndex = textInfo.pageInfo[dialogPage - 1].lastCharacterIndex;

        //if (DailyMessageText.maxVisibleCharacters < pageLastCharIndex)
        //{
        //    DailyMessageText.maxVisibleCharacters = pageLastCharIndex;
        //    if (dialogPage == pageCount)
        //    {
        //        SetButtonActive(NextButton, false);
        //    }
        //}
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
}
