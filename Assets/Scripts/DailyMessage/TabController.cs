using System;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField] private TabObject tabButtonPrefab;
    private List<TabObject> tabList = new List<TabObject>();
    [SerializeField] private DailyMessageManager dailyMessageManager;
    [SerializeField] private Transform dailyMessagePanel;

    public void LoadTabs()
    {
        for (int i = 0; i < dailyMessageManager.GetDailyMessageCount(); i++)
        {
            AddTab(i);
            tabList[i].setSelected(true);
            if (i >= 1)
            {
                tabList[i-1].setSelected(false);
            }
        }
    }

    public void AddTab(int pageIndex)
    {
        TabObject tabButton = Instantiate(tabButtonPrefab, dailyMessagePanel);
        tabButton.Init(this, pageIndex);

        tabList.Add(tabButton);
    }

    public void SwitchPage(int pageIndex)
    {
        dailyMessageManager.SwitchDailyMessage(pageIndex);
        for (int i = 0; i < tabList.Count; i++) 
        {
            tabList[i].setSelected(i == pageIndex);
        }
    }
}
