using UnityEngine;
using UnityEngine.UI;

public class SkillSlotUI : MonoBehaviour
{
    public Image skillIcon;

    public Image coolTimeImg;

    float selectedSkillCoolTime;
    float currentCoolTime = 0f;

    private void Reset()
    {
        skillIcon = this.TryFindChild("SkillIcon").GetComponent<Image>();
        coolTimeImg = this.TryFindChild("coolTimeImg").GetComponent<Image>();
    }

    private void Update()
    {
        if (0f < currentCoolTime)
        {
            currentCoolTime -= Time.deltaTime;
            coolTimeImg.fillAmount = currentCoolTime / selectedSkillCoolTime;
        }
        else
        {
            currentCoolTime = 0f;
            coolTimeImg.fillAmount = 0;
        }
    }

    public void SkillExcute()
    {
        currentCoolTime = selectedSkillCoolTime;
    }

    public void Init(int _SkillID)
    {
        SkillData data = SkillDataManager.Instance.GetSkillData(_SkillID);
        skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_" + _SkillID.ToString());
        selectedSkillCoolTime = data.coolTime;
    }

}
