using UnityEngine;
using UnityEngine.UI;

public class PlayerStatUI : UIBase
{
    public Button strButton;
    public Button hpButton;

    private void Reset()
    {
        strButton = this.TryFindChild("StrBtn").GetComponent<Button>();
        hpButton = this.TryFindChild("HpBtn").GetComponent<Button>();
    }

    private void Awake()
    {
        strButton.onClick.AddListener(OnStrClick);

    }

    public void OnStrClick()
    {
        if(true == Player.Instance.StrUpgrade())
        {

        }
    }

    public void OnHpClick()
    {
        if (true == Player.Instance.StrUpgrade())
        {

        }
    }

}
