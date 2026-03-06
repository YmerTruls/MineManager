using System;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField] private TabButton tabButtonPrefab;
    private List<TabButton> TabList = new List<TabButton>();
    [SerializeField] private DailyMessageManager DailyMessageManager;
    [SerializeField] private Transform DailyMessagePanel;

    public void AddTab(int pageIndex)
    {
        Debug.Log("Added: " + pageIndex);

        TabButton tabButton = Instantiate(tabButtonPrefab, DailyMessagePanel);
        tabButton.Init(this, pageIndex);

        TabList.Add(tabButton);
    }

    public void SwitchPage(int pageIndex)
    {
        DailyMessageManager.SwitchDailyMessage(pageIndex);
    }
}
