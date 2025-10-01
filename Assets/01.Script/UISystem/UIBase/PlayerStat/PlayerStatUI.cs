using UnityEngine.UI;

public class PlayerStatUI : UIBase
{
    public Button strButton;
    public Button hpButton;
    public Button cDamageButton;
    public Button cChanceButton;

    private void Reset()
    {
        strButton = this.TryFindChild("StrBtn").GetComponent<Button>();
        hpButton = this.TryFindChild("HpBtn").GetComponent<Button>();
        cDamageButton = this.TryFindChild("CriticalDamageBtn").GetComponent<Button>();
        cChanceButton = this.TryFindChild("CriticalChanceBtn").GetComponent<Button>();
    }

    private void Awake()
    {
        strButton.onClick.AddListener(OnStrClick);
        hpButton.onClick.AddListener(OnHpClick);
        cDamageButton.onClick.AddListener(OnCDamageClick);
        cChanceButton.onClick.AddListener(OnCChanceClick);

    }

    public void OnStrClick()
    {
        if (true == Player.Instance.StrUpgrade())
        {

        }
    }

    public void OnHpClick()
    {
        if (true == Player.Instance.HpUpgrade())
        {

        }
    }

    public void OnCDamageClick()
    {
        if (true == Player.Instance.CDamageUpgrade())
        {

        }
    }

    public void OnCChanceClick()
    {
        if (true == Player.Instance.CChanceUpgrade())
        {

        }
    }

}
