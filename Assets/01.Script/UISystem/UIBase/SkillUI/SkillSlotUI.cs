using UnityEngine;
using UnityEngine.UI;

public class SkillSlotUI : MonoBehaviour
{
    public Image skillIcon;

    public Image coolTimeImg;

    public Button skillBtn;

    float selectedSkillCoolTime;
    float currentCoolTime = 0f;

    public int SlotIndex;
    public int SkillID = -1;

    bool skillChangeMode = false;

    private void Reset()
    {
        skillIcon = this.TryFindChild("SkillIcon").GetComponent<Image>();
        coolTimeImg = this.TryFindChild("coolTimeImg").GetComponent<Image>();
        skillBtn = transform.GetComponent<Button>();
    }

    private void Start()
    {
        skillBtn.onClick.AddListener(OnClickSkill);
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
            SkillID = -1;
            skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_-1");
            return;
        }

        currentCoolTime = skillManager.GetSkillCoolTime(SlotIndex);
        selectedSkillCoolTime = data.coolTime;
        SkillID = data.skillID;

        skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Skill_" + data.skillID.ToString());
    }

    public void SkillChangeMode()
    {
        skillIcon.sprite = ResourceManager.Instance.GetOnLoadedSprite("Sprite/Change");
        skillChangeMode = true;
    }

    public void EndSkillChangeMode()
    {
        Init();
        skillChangeMode = false;
    }

    void OnClickSkill()
    {
        if (true == skillChangeMode)
        {
            UIManager uiManager = UIManager.Instance;
            SkillContainerUI containerUI = uiManager.GetUI<SkillContainerUI>();
            int selectedSkillID = containerUI.selectedSkillID;
            SkillUI skillUI = uiManager.GetUI<SkillUI>();

            SkillManager skillManager = SkillManager.Instance;

            int skillSlotNumber = skillManager.IsEquipmentSkill(selectedSkillID);

            if (-1 == skillSlotNumber)  // 현재 장착중인 스킬이 아니라면
            {
                skillManager.SelectSkill(SlotIndex, selectedSkillID);  // 현재 칸에 스킬 넣고
                this.SkillID = selectedSkillID;  //내가 참조중인 스킬 id도 바꿔주고
                Init(); // 다시 초기화
            }
            else  //현재 장착중인 스킬이라면
            {
                //현재 장착중인 스킬 슬롯에 스킬을 없애버리고
                skillManager.UnSelectSkill(skillSlotNumber);
                //해당 슬롯의 스킬 ui도 업데이트해주고
                //skillUI.UnSelectSkill(skillSlotNumber);
                //나는 다시 스킬 선택
                skillManager.SelectSkill(SlotIndex, selectedSkillID);
                // 아이고 머리 터지겠다
            }
            skillUI.EndSkillChangeMode();
        }
    }
}
