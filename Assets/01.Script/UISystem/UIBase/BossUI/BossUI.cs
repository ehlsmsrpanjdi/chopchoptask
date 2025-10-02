using UnityEngine.UI;

public class BossUI : UIBase
{
    public Image timerFillImg;
    public Image bossHpFillImg;

    private void Reset()
    {
        timerFillImg = this.TryFindChild("TimerFilled").GetComponent<Image>();
        bossHpFillImg = this.TryFindChild("BossHP").GetComponent<Image>();
    }

    public override void OnUI()
    {
        base.OnUI();
        SetHpRatio(1f);
        SetTimerRatio(1f);
    }
    public void SetTimerRatio(float ratio)
    {
        timerFillImg.fillAmount = ratio;
    }

    public void SetHpRatio(float ratio)
    {
        bossHpFillImg.fillAmount = ratio;
    }
}
