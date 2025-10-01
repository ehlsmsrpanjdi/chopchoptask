using UnityEngine.UI;

public class SelectorUI : UIBase
{
    public Button statBtn;
    public Button skillBtn;
    public Button invenBtn;

    private void Reset()
    {
        statBtn = this.TryFindChild("StatBtn").GetComponent<Button>();
        skillBtn = this.TryFindChild("SkillBtn").GetComponent<Button>();
        invenBtn = this.TryFindChild("InvenBtn").GetComponent<Button>();
    }

    private void Start()
    {
        statBtn.onClick.AddListener(OnClickStat);
        skillBtn.onClick.AddListener(OnClickSkill);
        invenBtn.onClick.AddListener(OnClickInven);
        UIManager.Instance.OnUI<PlayerStatUI>();
        UIManager.Instance.GetUI<SkillUI>().OffUI();
    }

    void OnClickStat()
    {
        UIManager.Instance.OnUI<PlayerStatUI>();
        UIManager.Instance.OffUI<SkillUI>();
    }

    void OnClickSkill()
    {
        UIManager.Instance.OffUI<PlayerStatUI>();
        UIManager.Instance.OnUI<SkillUI>();
    }

    void OnClickInven()
    {
        UIManager.Instance.OnUI<SkillContainerUI>();
    }
}
