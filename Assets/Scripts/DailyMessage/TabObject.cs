using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabObject : MonoBehaviour
{
    [SerializeField] private TMP_Text TabNumberText;
    private int tabIndex;
    private TabController parent;
    private RectTransform rect;

    public void Init(TabController parent, int tabIndex)
    {
        this.parent = parent;
        this.tabIndex = tabIndex;
        TabNumberText.SetText((tabIndex+1).ToString());

        GetComponent<Button>().onClick.AddListener(OnClick);
        Vector3 offset = new Vector3(0, -13 * tabIndex, 0);

        transform.localPosition += offset;
        rect = GetComponent<RectTransform>();
    }

    void OnClick()
    {
        parent.SwitchPage(tabIndex);

        // Play sound on click
        AudioManager.Instance.Play("FormSound");
    }

    public void setSelected(bool selected)
    {
        if (selected)
        {
            TabNumberText.SetText("Day " + (tabIndex + 1).ToString());
            rect.sizeDelta = new Vector2(32, 14);
        }
        else
        {
            TabNumberText.SetText((tabIndex + 1).ToString());
            rect.sizeDelta = new Vector2(12, 14);
        }
    }
}
