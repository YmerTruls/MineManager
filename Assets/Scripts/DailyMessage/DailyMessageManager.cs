using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DailyMessageManager : MonoBehaviour
{
    private int day;
    //[SerializeField] private SaveObject saveObject;
    private int MessageIndex;
    public TMP_Text DailyMessageText;
    [SerializeField] private TabController TabManager;

    // Page info:
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject PreviousButton;
    private int dialogPage = 1;


    public void AddAndSetDailyMessage(string message)
    {
        SaveObject.Instance.MessageList.Add(message);
        SwitchDailyMessage(-1); // Switch to last message
        if (GetDailyMessageCount() > 1)
        {
            TabManager.LoadTabs();
        }
    }

    public int GetDailyMessageCount()
    {
        return SaveObject.Instance.MessageList.Count;
    }

    public void SwitchDailyMessage(int pageNumber)
    {
        // Allow for reverse indexing
        if (pageNumber < 0) { pageNumber += GetDailyMessageCount(); }

        MessageIndex = pageNumber;
        string message = SaveObject.Instance.MessageList[pageNumber];
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
