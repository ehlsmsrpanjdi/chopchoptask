using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class SkillContainerUI : UIBase
{
    public TextMeshProUGUI skillDiscription;
    public List<SkillViewUI> skillViews;
    public Button exitBtn;

    private void Reset()
    {
        skillDiscription = this.TryFindChild("SkillDiscription").GetComponent<TextMeshProUGUI>();
        skillViews = GetComponentsInChildren<SkillViewUI>().ToList<SkillViewUI>();
        exitBtn = this.TryFindChild("ExitBtn").GetComponent<Button>();
    }

    void Init()
    {
        for (int i = 1; i < skillViews.Count; ++i)
        {
            skillViews[i - 1].Init(i);
        }
    }

    private void Start()
    {
        exitBtn.onClick.AddListener(ClickExitBtn);
    }

    public void SetDiscription(string _Str)
    {
        skillDiscription.text = _Str;
    }

    void ClickExitBtn()
    {
        OffUI();
    }

}
