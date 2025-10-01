using UnityEngine;
using UnityEngine.UI;

public class SkillSlotUI : MonoBehaviour
{
    public Image skillIcon;

    public Image coolTimeImg;

    float selectedSkillCoolTime;
    float currentCoolTime = 0f;

    public int SlotIndex;

    private void Reset()
    {
        skillIcon = this.TryFindChild("SkillIcon").GetComponent<Image>();
        coolTimeImg = this.TryFindChild("coolTimeImg").GetComponent<Image>();
    }

    private void Update()
    {
        if (selectedSkillCoolTime == 0)
        {
            coolTimeImg.fillAmount = 1;
            return;
        }

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

    public void Init()
    {
        SkillManager skillManager = SkillManager.Instance;
        SkillData data = skillManager.GetEquipmentSkillData(SlotIndex);

        if (null == data)
        {
            currentCoolTime = 0;
            selectedSkillCoolTime = 0;
            skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_-1");
            return;
        }

        currentCoolTime = skillManager.GetSkillCoolTime(SlotIndex);
        selectedSkillCoolTime = data.coolTime;


        skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_" + data.skillID.ToString());
    }

}
