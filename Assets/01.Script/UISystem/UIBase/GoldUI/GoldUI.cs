using TMPro;

public class GoldUI : UIBase
{
    public TextMeshProUGUI goldText;

    private void Reset()
    {
        goldText = this.TryFindChild("GoldText").GetComponent<TextMeshProUGUI>();
    }

    public override void OnUI()
    {
        if (Player.Instance != null)
        {
            Player.Instance.GetGold();
        }
        base.OnUI();
    }


    public void TextUpdate()
    {
        int goldAmount = Player.Instance.GetGold();
        goldText.text = goldAmount.ToString();
    }
}
