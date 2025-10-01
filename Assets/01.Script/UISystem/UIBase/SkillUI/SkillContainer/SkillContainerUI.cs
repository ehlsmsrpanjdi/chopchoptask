using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class SkillContainerUI : UIBase
{
    public TextMeshProUGUI skillDiscription;
    public List<SkillViewUI> skillViews;
    public Button exitBtn;
    public Button equipmentBtn;

    public int selectedSkillID = -1;

    private void Reset()
    {
        skillDiscription = this.TryFindChild("SkillDiscription").GetComponent<TextMeshProUGUI>();
        skillViews = GetComponentsInChildren<SkillViewUI>().ToList<SkillViewUI>();
        exitBtn = this.TryFindChild("ExitBtn").GetComponent<Button>();
        equipmentBtn = this.TryFindChild("EquipmentBtn").GetComponent<Button>();
    }

    public override void OnUI()
    {
        base.OnUI();
        Init();
    }

    bool isInit = false;

    void Init()
    {
        if (true == isInit)
        {
            SetDiscription("");
            selectedSkillID = -1;
            return;
        }
        for (int i = 1; i < skillViews.Count; ++i)
        {
            if (false == skillViews[i - 1].Init(i))
            {
                break;
            }
        }
        isInit = true;
    }

    private void Start()
    {
        exitBtn.onClick.AddListener(ClickExitBtn);
        equipmentBtn.onClick.AddListener(ClickOnEquipmentBtn);
    }

    public void SetDiscription(string _Str)
    {
        skillDiscription.text = _Str;
    }

    void ClickExitBtn()
    {
        OffUI();
    }

    void ClickOnEquipmentBtn()
    {
        if (-1 == selectedSkillID)
        {
            return;
        }
        UIManager manager = UIManager.Instance;
        manager.OffUI<PlayerStatUI>();
        SkillUI skillUI = manager.GetUI<SkillUI>();
        skillUI.OnUI();

        skillUI.SkillChangeMode();

        OffUI();
    }
}
