using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    [SerializeField] private TMP_Text TabNumberText;
    private int tabIndex;
    private TabController parent;

    public void Init(TabController parent, int tabIndex)
    {
        this.parent = parent;
        this.tabIndex = tabIndex;
        TabNumberText.SetText((tabIndex+1).ToString());

        GetComponent<Button>().onClick.AddListener(OnClick);
        transform.position += new Vector3(0,-13/16.666666f * tabIndex, 0);

        Debug.Log("Id:" +  tabIndex + ", pos: " + transform.position);
    }

    void OnClick()
    {
        parent.SwitchPage(tabIndex);

        // Play sound on click
        AudioManager.Instance.Play("FormSound");
    }
}
